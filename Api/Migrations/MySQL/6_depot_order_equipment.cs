using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(6)]
    public class DepotOrderEquipmentTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("6_depot_order_equipment.sql");
        }

        public override void Down()
        {
        }
    }
}
