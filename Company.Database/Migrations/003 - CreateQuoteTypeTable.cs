using FluentMigrator;

namespace Company.Database.Migrations
{
    [Migration(3)]
    public class CreateQuoteTypeTable : Migration
    {
        public override void Up()
        {
            Create.Table("QuoteType")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
            Delete.Table("QuoteType");
        }
    }
}