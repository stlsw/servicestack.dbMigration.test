using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace TestServiceStackDbMigration.Migrations
{
    [Description("Update MyTable")]
    public class Migration1001 : MigrationBase
    {
        class MyTable
        {
            [Index]
            public string Code { get; set; }

            [RenameColumn("Name")]
            public string? FullName { get; set; }

            [RemoveColumn]
            public double ToDelete { get; set; }
        }

        public override void Up() => Db.Migrate<MyTable>();
        public override void Down() => Db.Revert<MyTable>();
    }
}