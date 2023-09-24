using System.Collections.Generic;
using System.Linq;

namespace PassengerManagement
{
    public class PassengerManagementService
    {
        public IList<Family> CheckRulesAndGetFamilies(IList<Passenger> passengers)
        {
            if (passengers == null || !passengers.Any())
            {
                return new List<Family>();
            }

            IEnumerable<Family> families = passengers.GroupBy(_ => _.FamilyName).Select(p => new Family
            {
                Members = p.ToList(),
                Name = p.Key
            });

            return families.Where(f => f.Members.Any(m => m.Type == PassengerType.Adult)
                && f.Members.Count(m => m.Type == PassengerType.Adult) <= 2
                && f.Members.Count(m => m.Type == PassengerType.Children) <= 3
                && !f.Members.Any(m => m.Type == PassengerType.Children && m.NeedTwoPlaces)).ToList();
        }

        public decimal GetOptimizedTurnover(List<Family> families, int availablePlace)
        {
            families = families.OrderByDescending(family => family.TotalPrice)
                    .ThenBy(family => family.TotalPlace)
                    .ToList();

            List<Family> selectedFamilies = new();

            while (families.Any() && availablePlace > 0)
            {
                var profitableFamily = families.FirstOrDefault(family => family.TotalPlace <= availablePlace);

                if (profitableFamily != null)
                {
                    selectedFamilies.Add(profitableFamily);
                    availablePlace -= profitableFamily.TotalPlace;
                    families.Remove(profitableFamily);
                }
                else
                {
                    bool isChecked = false;
                    foreach (var family in new List<Family>(families))
                    {
                        var selectedFamilyToRemove = selectedFamilies.Where(f => f.TotalPrice < family.TotalPrice).OrderBy(f => f.TotalPrice);
                        decimal sumTotal = 0;
                        int availablePlaceAdded = availablePlace;
                        List<Family> familiesToRemove = new();
                        foreach (var familySelected in selectedFamilyToRemove)
                        {
                            if (sumTotal <= family.TotalPrice)
                            {
                                sumTotal += familySelected.TotalPrice;
                                availablePlaceAdded += familySelected.TotalPlace;
                                familiesToRemove.Add(familySelected);
                            }
                        }

                        if (families.FirstOrDefault(family => family.TotalPlace < availablePlaceAdded) != null)
                        {
                            families.InsertRange(1, familiesToRemove);
                            selectedFamilies.RemoveAll(f => familiesToRemove.Any(fr => fr.Name == f.Name));
                            availablePlace = availablePlaceAdded;
                            isChecked = true;
                        }
                    }

                    if(!isChecked)
                    {
                        break;
                    }
                }
            }

            return selectedFamilies.Sum(f => f.TotalPrice);
        }
    }
}
