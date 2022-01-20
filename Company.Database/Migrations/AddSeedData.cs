using Company.Common.DatabaseModels;
using Company.Database;

namespace Company.Database.Migrations
{
    public class AddSeedData
    {
        private readonly CompanyContext _dbContext;

        public AddSeedData(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void LoadData()
        {
            var audi = new Make() { Id = 1, Text = "Audi" };
            var bmw = new Make() { Id = 2, Text = "BMW" };
            _dbContext.Makes.Add(audi);
            _dbContext.Makes.Add(bmw);

            var car = new VehicleType() { Id = 1, Text = "Car" };
            var van = new VehicleType() { Id = 2, Text = "Van" };
            var bike = new VehicleType() { Id = 3, Text = "Bike" };

            _dbContext.VehicleTypes.Add(car);
            _dbContext.VehicleTypes.Add(van);
            _dbContext.VehicleTypes.Add(bike);

            var pcp = new QuoteType() { Id = 1, Text = "PCP" };
            var hp = new QuoteType() { Id = 2, Text = "HP" };

            _dbContext.QuoteTypes.Add(pcp);
            _dbContext.QuoteTypes.Add(hp);

            AddVehicleQuote(audi, car, pcp, 5, 6, 7, 8);
            AddVehicleQuote(audi, car, hp, 6, 7, 8, 9);
            AddVehicleQuote(audi, van, pcp, 4, 4, 4, 4);
            AddVehicleQuote(bmw, bike, hp, 5, 6, 7, 8);

            _dbContext.SaveChanges();
        }

        private void AddVehicleQuote(
            Make make,
            VehicleType vehicleType,
            QuoteType quoteType,
            decimal zeroToThreeMonthsApr,
            decimal threeToSixMonthsApr,
            decimal sixToTwelveMonthsApr,
            decimal overTwelveMonthsApr)
        {
            _dbContext.VehicleQuotes.Add(new VehicleQuote()
            {
                MakeId = make.Id,
                VehicleTypeId = vehicleType.Id,
                QuoteTypeId = quoteType.Id,
                ZeroToThreeMonthsApr = zeroToThreeMonthsApr,
                ThreeToSixMonthsApr = threeToSixMonthsApr,
                SixToTwelveMonthsApr = sixToTwelveMonthsApr,
                OverTwelveMonthsApr= overTwelveMonthsApr,
            });
        }
    }
}
