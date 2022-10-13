using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceStackDbMigration.Migrations
{
    [Description("Rename")]
    public class Migration1003 : MigrationBase
    {
        public override void Up()
        {
            Db.RenameColumn(table: "MyTable", oldColumn: "Name", newColumn: "FullName");
        }

        public override void Down()
        {
            Db.RenameColumn(table: "MyTable", oldColumn: "FullName", newColumn: "Name");
        }
    }
}