
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class EXITAAndroidBuilder
{
    [MenuItem("EXITA/Build Android APK")]
    public static void BuildAndroid()
    {
        string outputPath = "Build/EXITA_UTARA.apk";

        BuildPlayerOptions options = new BuildPlayerOptions();

        options.scenes = new[]
        {
            "Assets/Scenes/PokokJawi.unity"
        };

        options.locationPathName = outputPath;
        options.target = BuildTarget.Android;
        options.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(options);

        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("EXITA Android APK created: " + outputPath);
        }
        else
        {
            Debug.LogError("Android build failed: " +
                report.summary.result);
        }
    }
}
