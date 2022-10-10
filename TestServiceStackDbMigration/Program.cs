/*
 * 安装包：
 * ServiceStack.OrmLite
 * ServiceStack.OrmLite.MySql
 */

using ServiceStack.OrmLite;
using TestServiceStackDbMigration.Migrations;

var dbFactory = new OrmLiteConnectionFactory("Server=localhost;Database=TestServiceStack;Uid=root;Pwd=password;", MySqlDialect.Provider);

#region 方法一
//var migrator = new Migrator(dbFactory, typeof(Migration1000).Assembly);
//var result = migrator.Run();
//var result = migrator.Revert(Migrator.All);   // 还原数据库未成功。
//Console.WriteLine(result.Succeeded);   // 输出升级结果。
#endregion

#region 方法二
// Migration1001 未升级成功，程序正常运行，但调试模式可以看到有错误。
Migrator.Up(dbFactory, new[] { typeof(Migration1000), typeof(Migration1001) });   // 或单个文件升级 Migrator.Up(dbFactory, typeof(Migration1000));
//Migrator.Down(dbFactory, typeof(Migration1001));   // 可以和 UP 分开测试。
Console.WriteLine("升级完成。");
#endregion

Console.ReadLine();