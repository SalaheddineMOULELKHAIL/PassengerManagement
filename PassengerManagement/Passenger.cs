namespace PassengerManagement
{
    public class Passenger
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public bool NeedTwoPlaces { get; set; }

        public string FamilyName { get; set; }

        public PassengerType Type => Age > 12 ? PassengerType.Adult : PassengerType.Children;

        public decimal Price => Type == PassengerType.Adult ? NeedTwoPlaces ? 500 : 250 : 150;
    }
}
