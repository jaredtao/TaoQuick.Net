using System;

using Qml.Net;
using Qml.Net.Runtimes;
namespace TaoQuick_DotNet
{
    class main
    {
        static int Main(string[] args)
        {
            RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
            QQuickStyle.SetStyle("Material");
            using (var app = new QGuiApplication(args))
            {
                using (var engine = new QQmlApplicationEngine())
                {
                    engine.AddImportPath(Config.Config.importPath);
                    engine.SetContextProperty("resPath", Config.Config.resPath);
                    engine.Load(Config.Config.qmlPath + "main.qml");
                    return app.Exec();
                }
            }
        }
    }
}
