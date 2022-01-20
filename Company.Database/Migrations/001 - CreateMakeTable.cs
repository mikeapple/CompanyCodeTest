using FluentMigrator;

namespace Company.Database.Migrations
{
    [Migration(1)]
    public class CreateMakeTable : Migration
    {
        public override void Up()
        {
            Create.Table("Make")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
            Delete.Table("Make");
        }
    }
}