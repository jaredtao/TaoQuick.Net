$cur= Get-Location

$configFileTemplate=@"
using System;

namespace Config 
{
    public class Config
    {
        readonly public static String qmlPath="file:///{0}";
        readonly public static String imgPath="file:///{1}";
        readonly public static String importPath="file:///{2}";
        readonly public static String transPath="{3}";
        readonly public static String contentsPath="file:///{4}";
        
    }
}
"@
$qmlPath=$cur.ToString() + "/Qml/"
$imgPath=$cur.ToString() + "/Image/"
$importPath=$cur.ToString() + "/imports/"
$transPath=$cur.ToString() + "/Trans/"
$contentsPath=$cur.ToString() + "/Contents/"

$str=$configFileTemplate; 
$str=$str.Replace("{0}", $qmlPath)
$str=$str.Replace("{1}", $imgPath)
$str=$str.Replace("{2}", $importPath)  
$str=$str.Replace("{3}", $transPath)  
$str=$str.Replace("{4}", $contentsPath)  
$str=$str.Replace("\", "/"); 

Out-File -Encoding "utf8"  -FilePath Config.cs -InputObject $str