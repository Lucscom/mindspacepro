using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class VisualStudioProjectGenerationPostProcess : AssetPostprocessor
{


    public static string oldFramework = "4.7.1";
    public static string newFramework = "3.5";



    private static void OnGeneratedCSProjectFiles()
        {
            Debug.Log("OnGeneratedCSProjectFiles");
            var dir = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(dir, "*.csproj");
            foreach (var file in files)
                ChangeTargetFrameworkInfProjectFiles(file);
        }

    static void ChangeTargetFrameworkInfProjectFiles(string file)
    {
        string text = File.ReadAllText(file);
        string find = "TargetFrameworkVersion>v" + oldFramework + "</TargetFrameworkVersion";
        string replace = "TargetFrameworkVersion>v" + newFramework + "</TargetFrameworkVersion";

        if (text.IndexOf(find) != -1)
        {
            text = Regex.Replace(text, find, replace);
            File.WriteAllText(file, text);
        }
    }
}