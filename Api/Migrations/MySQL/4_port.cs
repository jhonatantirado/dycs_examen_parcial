using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(4)]
    public class PortTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("4_port.sql");
        }

        public override void Down()
        {
        }
    }
}
