using Company.Common.ClientModels;

namespace Company.Api.Services
{
    public interface IVehicleService
    {
        AprDetails AddAprDetails(int makeId, int vehicleTypeId, int quoteTypeId, decimal zeroToThreeMonthsApr, decimal threeToSixMonthsApr, decimal sixToTwelveMonthsApr, decimal overTwelveMonthsApr);
        Make AddMake(string text);
        QuoteType AddQuoteType(string text);
        VehicleType AddVehicleType(string text);
        List<AprDetails> GetAprDetails();
        List<Make> GetMakes();
    }
}