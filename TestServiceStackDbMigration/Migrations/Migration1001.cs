using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace TestServiceStackDbMigration.Migrations
{
    [Description("Update MyTable")]
    public class Migration1001 : MigrationBase
    {
        class MyTable
        {
            // 通过该注释更新会创建主键，如果表中已存在主键，则更新失败。
            // Migration1002 通过替代方法添加带索引字段，也不可行。
            // 目前没有找到在已有主键的表中添加带索引字段的方法。
            //[Index]
            //public string Code { get; set; }

            // 使用该注释更名，报错。
            //[RenameColumn("Name")]
            //public string? FullName { get; set; }

            [RemoveColumn]
            public double ToDelete { get; set; }
        }

        public override void Up() => Db.Migrate<MyTable>();
        public override void Down() => Db.Revert<MyTable>();
    }
}