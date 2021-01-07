$cur= Get-Location

$configFileTemplate=@"
using System;

namespace Config 
{
    public class Config
    {
        readonly public static String qmlPath="{0}";
        readonly public static String resPath="{1}";
        readonly public static String importPath="{2}";
    }
}
"@
$qmlPath=$cur.ToString() + "/Qml/"
$resPath=$cur.ToString() + "/Res/"
$importPath=$cur.ToString() + "/imports/"

$str=$configFileTemplate; 
$str=$str.Replace("{0}", $qmlPath)
$str=$str.Replace("{1}", $resPath)
$str=$str.Replace("{2}", $importPath)  
$str=$str.Replace("\", "/"); 
Out-File -Encoding "utf8"  -FilePath Config.cs -InputObject $str