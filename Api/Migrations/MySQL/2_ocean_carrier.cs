using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(2)]
    public class OceanCarrierTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_ocean_carrier.sql");
        }

        public override void Down()
        {
        }
    }
}
