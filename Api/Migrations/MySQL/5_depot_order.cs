using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(5)]
    public class DepotOrderTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_depot_order.sql");
        }

        public override void Down()
        {
        }
    }
}
