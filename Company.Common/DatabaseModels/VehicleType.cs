namespace Company.Common.DatabaseModels
{
    public class VehicleType
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<VehicleQuote> VehicleQuotes { get; set; }
    }
}
