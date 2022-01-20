using FluentMigrator;

namespace Company.Database.Migrations
{
    [Migration(4)]
    public class CreateVehicleQuoteTable : Migration
    {
        public override void Up()
        {
            Create.Table("VehicleQuote")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("MakeId").AsInt64().NotNullable()
                .WithColumn("VehicleTypeId").AsInt64().NotNullable()
                .WithColumn("QuoteTypeId").AsInt64().NotNullable()
                .WithColumn("ZeroToThreeMonthsApr").AsDecimal().NotNullable()
                .WithColumn("ThreeToSixMonthsApr").AsDecimal().NotNullable()
                .WithColumn("SixToTwelveMonthsApr").AsDecimal().NotNullable()
                .WithColumn("OverTwelveMonthsApr").AsDecimal().NotNullable();

            Create.ForeignKey("fk_vehiclequote_make").FromTable("Make").ForeignColumn("Id").ToTable("VehicleQuote").PrimaryColumn("MakeId");
            Create.ForeignKey("fk_vehiclquote_vehicletype").FromTable("VehicleType").ForeignColumn("Id").ToTable("VehicleQuote").PrimaryColumn("VehicleTypeId");
            Create.ForeignKey("fk_vehiclequote_quotetype").FromTable("QuoteType").ForeignColumn("Id").ToTable("VehicleQuote").PrimaryColumn("QuoteTypeId");    
        }

        public override void Down()
        {
            Delete.Table("VehicleQuote");

            Delete.ForeignKey().FromTable("Make").ForeignColumns("Id");
            Delete.ForeignKey().FromTable("VehicleType").ForeignColumns("Id");
            Delete.ForeignKey().FromTable("QuoteType").ForeignColumns("Id");
        }
    }
}