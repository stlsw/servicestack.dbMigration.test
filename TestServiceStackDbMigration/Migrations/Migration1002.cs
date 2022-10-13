using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceStackDbMigration.Migrations
{
    /// <summary>
    /// 此更新不可用。
    /// </summary>
    public class Migration1002 : MigrationBase
    {
        public override void Up()
        {
            Db.AddColumn(table: "MyTable", new FieldDefinition
            {
                Name = "Code",
                FieldType = typeof(string),
                IsIndexed = true   // 未创建索引
            });
        }

        public override void Down()
        {
            Db.DropColumn(table: "MyTable", column: "Code");
        }
    }
}