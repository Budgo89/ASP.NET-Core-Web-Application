using System;

namespace WebApiServis.Migrations
{
    public class Migrator_1
    {
        //public Action<string> OnNewUpdateLog;

        //public void UpdateToLatestVersion(string databaseName, string migrationNamespace)
        //{
        //    //указывает событие, которое будет использоваться в качестве вывода всех сообщений от FluentMigrator-a
        //    var announcer = new TextWriterAnnouncer(OnNewUpdateLog);

        //    // получаем текущую сбору
        //    var assembly = Assembly.GetExecutingAssembly();

        //    // создаем новый контекст и указывает пространство имен, которое содержит классы миграции
        //    var migrationContext = new RunnerContext(announcer)
        //    {
        //        Namespace = migrationNamespace
        //    };

        //    var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };

        //    //создаем фабрику для SqlServer2008
        //    var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
        //    var processor = factory.Create(GetConnectionString(databaseName), announcer, options);

        //    //создаем новый runner
        //    var runner = new MigrationRunner(assembly, migrationContext, processor);

        //    //выполняем миграцию к последней версии
        //    runner.MigrateUp(true);
        //    OnNewUpdateLog("Done");
        //}
	}
}
