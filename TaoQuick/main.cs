using System;

using Qml.Net;
using Qml.Net.Runtimes;
namespace TaoQuick
{
    class main
    {
        static void prepareApp() {
            QQuickStyle.SetStyle("Material");
            QGuiApplication.SetAttribute(ApplicationAttribute.EnableHighDpiScaling, true);
            QGuiApplication.SetAttribute(ApplicationAttribute.UseHighDpiPixmaps, true);
            
            QGuiApplication.OrganizationName = "JaredTao";
            QGuiApplication.OrganizationDomain = "https://JaredTao.gitee.io";
        }
        static int Main(string[] args)
        {
            RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
            
            using (var app = new QGuiApplication(args))
            {
                Qml.Net.Qml.RegisterType<Trans>("TaoQuickNet");
                var trans = new Trans();
                trans.loadFolder(Config.Config.transPath);
                using (var engine = new QQmlApplicationEngine())
                {
                    Console.WriteLine("importPath " + Config.Config.importPath);
                    Console.WriteLine("imgPath " + Config.Config.imgPath);

                    engine.AddImportPath(Config.Config.importPath);
                    engine.SetContextProperty("imgPath", Config.Config.imgPath);
                    engine.SetContextProperty("qmlPath", Config.Config.qmlPath);
                    engine.SetContextProperty("contentsPath", Config.Config.contentsPath);
                    engine.SetContextProperty("isDebug", true);
                    
                    engine.SetContextProperty("taoQuickImagePath", Config.Config.importPath + "TaoQuick/Images/");

                    engine.SetContextProperty("trans", trans);

                    engine.Load(Config.Config.qmlPath + "main.qml");
                    return app.Exec();
                }
            }
        }
    }
}
