using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Company.Tests
{
    public class VehicleTests
    {
        [Fact]
        public async Task MakeIsSaved()
        {
            var context = new TestContext();

            var randomText = Guid.NewGuid().ToString("N");

            var result = context.VehicleService.AddMake(randomText);

            Assert.NotNull(await context.DbContext.Makes.FirstOrDefaultAsync(f => f.Text == randomText));
        }

        [Fact]
        public async Task AprDetailsReturned()
        {
            var context = new TestContext();

            var result = context.VehicleService.GetAprDetails();

            Assert.Equal(await context.DbContext.VehicleQuotes.CountAsync(), result.Count);
        }
    }
}