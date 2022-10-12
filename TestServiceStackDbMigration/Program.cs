/*
 * 官方文档：
 * https://docs.servicestack.net/releases/v6_3#code-first-db-migrations
 * 
 * 安装包：
 * ServiceStack.OrmLite
 * ServiceStack.OrmLite.MySql
 */

using ServiceStack.OrmLite;
using TestServiceStackDbMigration.Migrations;

var dbFactory = new OrmLiteConnectionFactory("Server=localhost;Database=TestServiceStack;Uid=root;Pwd=password;", MySqlDialect.Provider);

#region 方法一。建议用第一种方法，可以判断升级是否成功。
/* migration 表中记录更新执行情况。
 * 一、比如执行“Migration1000”后，删除表 MyTable ，
 *     即使再执行“Migration1000”，也不会再创建表 MyTable 。
 * 二、若更新失败，必须删除未执行的更新记录，才能继续更新。
 *     比如执行“Migration1001”失败，记录中没有记录完成时间，
 *     这个时候再实行更新，抛异常：“Migration1001”仍在更新，
 *     只有删除“Migration1000”更新记录，才能继续更新。
 * 三、通过控制台更新，会输出具体的执行过程。如：发现了哪些更新，执行了什么语句，执行结果等。
*/
//var migrator = new Migrator(dbFactory, typeof(Migration1000));   // 执行单个更新
//var migrator = new Migrator(dbFactory, typeof(Migration1000).Assembly);   // 执行所有更新。
//var migrator = new Migrator(dbFactory, typeof(Migration1001));
var migrator = new Migrator(dbFactory, typeof(Migration1002));
try
{
    var result = migrator.Run();
    Console.WriteLine(result.Succeeded);   // 输出升级结果。
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//var result = migrator.Revert(nameof(Migration1000));   // 还原数据库。
//Console.WriteLine(result.Succeeded);

// 不要使用这个方法，这个方法会清空表 migration 中的所有更新记录。
//var db = dbFactory.Open();
//Migrator.Clear(db);

#endregion

#region 方法二。调试模式可以看到升级失败报错，但不抛异常；没有升级记录（不创建表migration）
// Migration1001 未升级成功，程序正常运行，但调试模式可以看到有错误。
//Migrator.Up(dbFactory, new[] { typeof(Migration1000), typeof(Migration1001) });   // 或单个文件升级 Migrator.Up(dbFactory, typeof(Migration1000));
//Migrator.Down(dbFactory, typeof(Migration1001));   // 可以和 UP 分开测试。
//Console.WriteLine("升级完成。");
#endregion

Console.WriteLine("迁移完成。");
Console.ReadLine();