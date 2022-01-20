namespace Company.Common.DatabaseModels
{
    public class VehicleQuote
    {
        public int Id { get; set; }

        public int MakeId { get; set; }
        public Make Make { get; set; }

        public int QuoteTypeId { get; set; }
        public QuoteType QuoteType { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public decimal ZeroToThreeMonthsApr { get; set; }

        public decimal ThreeToSixMonthsApr { get; set; }

        public decimal SixToTwelveMonthsApr { get; set; }

        public decimal OverTwelveMonthsApr { get; set; }
    }
}
