using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(1)]
    public class CurrencyTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1_currency.sql");
        }

        public override void Down()
        {
        }
    }
}
