using System.Collections.Generic;
using System.Linq;

namespace PassengerManagement
{
    public class Family
    {
        public string Name { get; set; }

        public IList<Passenger> Members { get; set; }

        public decimal TotalPrice => Members.Sum(m => m.Price);

        public int TotalPlace => 2 * Members.Count(m => m.NeedTwoPlaces) + Members.Count(m => !m.NeedTwoPlaces);
    }
}
