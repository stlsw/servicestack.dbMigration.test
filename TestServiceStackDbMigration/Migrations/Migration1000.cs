using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace TestServiceStackDbMigration.Migrations
{
    [Description("Create initial database tables")]
    public class Migration1000 : MigrationBase
    {
        public class MyTable
        {
            [AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public double ToDelete { get; set; }
        }

        public override void Up()
        {
            Db.CreateTable<MyTable>();
        }

        public override void Down()
        {
            Db.DropTable<MyTable>();
        }
    }
}