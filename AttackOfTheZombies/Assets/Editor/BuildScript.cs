using UnityEngine;
using System.Collections;
using UnityEditor;

using System.Collections.Generic;

public class BuildScript 
{
    static string[] scenes = FindEnabledEditorScenes();

    static string appName = "AttackOfTheZombie";
    static string targetDir = ("Build");

    [MenuItem("Build/Mac OS X")]
    static void BuildMacOSX()
    {
        string appTarget = appName + ".app";
        GenericBuild(scenes, targetDir + "/" + appTarget, BuildTarget.StandaloneOSXIntel, BuildOptions.None);
    }

    [MenuItem("Build/Windows(x86)")]
    static void BuildWindowsx86()
    {
        string appTarget = appName + ".exe";
        GenericBuild(scenes, targetDir + "/" + appTarget, BuildTarget.StandaloneWindows, BuildOptions.None);
    }

    static void GenericBuild(string[] scenes, string targetDir, BuildTarget buildTarget, BuildOptions buildOptions)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);
        string result = BuildPipeline.BuildPlayer(scenes, targetDir, buildTarget, buildOptions);
        if (result.Length > 0)
        {
            // we have an error
            System.Console.WriteLine("BuildPlayer Failure" + result);
            throw new System.Exception("BuildPlayer Failure: " + result);
        }
    }

    private static string[] FindEnabledEditorScenes()
    {
        List<string> EditorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }


}
