using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PassengerManagement.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var service = new PassengerManagementService();
            List<Passenger> passengers = new List<Passenger>{ 
            new Passenger {Age = 30, FamilyName = "A" },
                new Passenger { Age = 30, FamilyName = "A" },
                new Passenger { Age = 10, FamilyName = "A" },
                new Passenger { Age = 11, FamilyName = "A" },
                new Passenger { Age = 30, FamilyName = "B" },
                new Passenger { Age = 30, FamilyName = "B" },
                new Passenger { Age = 10, FamilyName = "B" },
                new Passenger { Age = 30, FamilyName = "C" },
                new Passenger { Age = 30, FamilyName = "C", NeedTwoPlaces = true },
                //new Passenger { Age = 30, FamilyName = "D" },
                //new Passenger { Age = 30, FamilyName = "E" },
                //new Passenger { Age = 8, FamilyName = "E" },
                new Passenger { Age = 30, FamilyName = "F" },
                new Passenger { Age = 11, FamilyName = "F" },
                new Passenger { Age = 11, FamilyName = "F" },
                new Passenger { Age = 30, FamilyName = "G" },
                new Passenger { Age = 30, FamilyName = "G" },
                new Passenger { Age = 7, FamilyName = "G" },
                new Passenger { Age = 30, FamilyName = "H", NeedTwoPlaces = true },
                new Passenger { Age = 30, FamilyName = "H" },
                //new Passenger { Age = 30, FamilyName = "I" },
                //new Passenger { Age = 30, FamilyName = "J" },
                //new Passenger { Age = 8, FamilyName = "J" },
                new Passenger { Age = 30, FamilyName = "K" , NeedTwoPlaces = true },
                new Passenger { Age = 30, FamilyName = "K"},
                new Passenger { Age = 30, FamilyName = "L" },
                new Passenger { Age = 30, FamilyName = "L" },
                new Passenger { Age = 11, FamilyName = "L" },
                new Passenger { Age = 30, FamilyName = "M" },
                new Passenger { Age = 2, FamilyName = "M" },
                new Passenger { Age = 11, FamilyName = "M" },
                new Passenger { Age = 30, FamilyName = "N" },
                new Passenger { Age = 30, FamilyName = "N" },
                new Passenger { Age = 11, FamilyName = "N" },
                new Passenger { Age = 11, FamilyName = "N" },
                new Passenger { Age = 30, FamilyName = "P" },
                 new Passenger { Age = 30, FamilyName = "Q" , NeedTwoPlaces = true},
                 new Passenger { Age = 30, FamilyName = "R" , NeedTwoPlaces = true},
                 new Passenger { Age = 30, FamilyName = "R" , NeedTwoPlaces = true},
                  new Passenger { Age = 30, FamilyName = "O" },
                 new Passenger { Age = 30, FamilyName = "O" },
                 new Passenger { Age = 12, FamilyName = "O" },
                 new Passenger { Age = 11, FamilyName = "O" },
                 new Passenger { Age = 9, FamilyName = "O" },
                     new Passenger { Age = 30, FamilyName = "S", NeedTwoPlaces = true },
                 new Passenger { Age = 30, FamilyName = "S" },
                 new Passenger { Age = 12, FamilyName = "S" },
                 new Passenger { Age = 11, FamilyName = "S" },
                 new Passenger { Age = 9, FamilyName = "S" },
                 new Passenger { Age = 30, FamilyName = "T"},
                 new Passenger { Age = 12, FamilyName = "T" },
                 new Passenger { Age = 11, FamilyName = "T" },
                 new Passenger { Age = 9, FamilyName = "T" },
                 new Passenger { Age = 30, FamilyName = "V"},
                 new Passenger { Age = 20, FamilyName = "V" },
                 new Passenger { Age = 11, FamilyName = "V" },
            };
            List<Family> families = service.CheckRulesAndGetFamilies(passengers).ToList();
            decimal result = service.GetOptimizedTurnover(families, 15);
        }
    }
}
