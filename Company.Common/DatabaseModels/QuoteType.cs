namespace Company.Common.DatabaseModels
{
    public class QuoteType
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public List<VehicleQuote> VehicleQuotes { get; set; }
    }
}
