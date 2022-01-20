namespace Company.Common.DatabaseModels
{
    public class Make
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<VehicleQuote> VehicleQuotes { get; set;}
    }
}
