using Company.Database;
using DatabaseModels = Company.Common.DatabaseModels;
using ClientModels = Company.Common.ClientModels;

namespace Company.Api.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly CompanyContext _dbContext;

        public VehicleService(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ClientModels.Make AddMake(string text)
        {
            var make = new DatabaseModels.Make() { Text = text };
            _dbContext.Makes.Add(make);

            _dbContext.SaveChanges();

            return new ClientModels.Make()
            {
                Id = make.Id,
                Text = text,
            };
        }

        public ClientModels.VehicleType AddVehicleType(string text)
        {
            var vehicleType = new DatabaseModels.VehicleType() { Text = text };
            _dbContext.VehicleTypes.Add(vehicleType);

            _dbContext.SaveChanges();

            return new ClientModels.VehicleType()
            {
                Id = vehicleType.Id,
                Text = text,
            };
        }

        public ClientModels.QuoteType AddQuoteType(string text)
        {
            var quoteType = new DatabaseModels.QuoteType() { Text = text };
            _dbContext.QuoteTypes.Add(quoteType);

            _dbContext.SaveChanges();

            return new ClientModels.QuoteType()
            {
                Id = quoteType.Id,
                Text = text,
            };
        }

        public ClientModels.AprDetails AddAprDetails(
            int makeId,
            int vehicleTypeId,
            int quoteTypeId,
            decimal zeroToThreeMonthsApr,
            decimal threeToSixMonthsApr,
            decimal sixToTwelveMonthsApr,
            decimal overTwelveMonthsApr)
        {
            var vehicleQuote = new DatabaseModels.VehicleQuote()
            {
                MakeId = makeId,
                VehicleTypeId = vehicleTypeId,
                QuoteTypeId = quoteTypeId,
                ZeroToThreeMonthsApr = zeroToThreeMonthsApr,
                ThreeToSixMonthsApr = threeToSixMonthsApr,
                SixToTwelveMonthsApr = sixToTwelveMonthsApr,
                OverTwelveMonthsApr = overTwelveMonthsApr
            };

            _dbContext.VehicleQuotes.Add(vehicleQuote);
            _dbContext.SaveChanges();

            return _dbContext.VehicleQuotes.Select(
                x => new ClientModels.AprDetails()
                {
                    Id = x.Id,
                    Make = x.Make.Text,
                    VehicleType = x.VehicleType.Text,
                    QuoteType = x.QuoteType.Text,
                    ZeroToThreeMonthApr = zeroToThreeMonthsApr,
                    ThreeToSixMonthApr = threeToSixMonthsApr,
                    SixToTwelveMonthApr = sixToTwelveMonthsApr,
                    OverTwelveMonthApr = overTwelveMonthsApr,
                }).First(f => f.Id == vehicleQuote.Id);
        }

        public List<ClientModels.Make> GetMakes()
        {
            return _dbContext.Makes.Select(m => new ClientModels.Make()
            {
                Id = m.Id,
                Text = m.Text,
            }).ToList();
        }

        public List<ClientModels.AprDetails> GetAprDetails()
        {
            return _dbContext.VehicleQuotes.Select(
                x => new ClientModels.AprDetails()
                {
                    Id = x.Id,
                    Make = x.Make.Text,
                    VehicleType = x.VehicleType.Text,
                    QuoteType = x.QuoteType.Text,
                    ZeroToThreeMonthApr = x.ZeroToThreeMonthsApr,
                    ThreeToSixMonthApr = x.ThreeToSixMonthsApr,
                    SixToTwelveMonthApr = x.SixToTwelveMonthsApr,
                    OverTwelveMonthApr = x.OverTwelveMonthsApr,
                }).ToList();
        }
    }
}
