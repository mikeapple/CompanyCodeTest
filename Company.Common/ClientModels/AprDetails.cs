namespace Company.Common.ClientModels
{
    public class AprDetails
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public string Make { get; set; }

        public int VehicleTypeId { get; set; }

        public string VehicleType { get; set; }

        public int QuoteTypeId { get; set; }

        public string QuoteType { get; set; }

        public decimal ZeroToThreeMonthApr { get; set; }

        public decimal ThreeToSixMonthApr { get; set; }

        public decimal SixToTwelveMonthApr { get; set; }

        public decimal OverTwelveMonthApr { get; set; }
    }
}
