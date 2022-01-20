using FluentMigrator;

namespace Company.Database.Migrations
{
    [Migration(2)]
    public class CreateVehicleTypeTable : Migration
    {
        public override void Up()
        {
            Create.Table("VehicleType")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
            Delete.Table("VehicleType");
        }
    }
}