
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using Exita.Utara.Map;

public class PokokJawiSceneGenerator
{
    [MenuItem("EXITA/Generate Pokok Jawi Scene")]
    public static void GenerateScene()
    {
        Scene scene = EditorSceneManager.NewScene(
            NewSceneSetup.DefaultGameObjects,
            NewSceneMode.Single
        );

        GameObject map = new GameObject("POKOK JAWI MAP");

        PokokJawiMapSetup setup =
            map.AddComponent<PokokJawiMapSetup>();

        setup.BuildMap();

        GameObject camera = GameObject.FindWithTag("MainCamera");

        if (camera != null)
        {
            camera.transform.position =
                new Vector3(1000f, 180f, -200f);

            camera.transform.rotation =
                Quaternion.Euler(35f, 0f, 0f);
        }

        string folder = "Assets/Scenes";

        if (!AssetDatabase.IsValidFolder(folder))
        {
            AssetDatabase.CreateFolder("Assets", "Scenes");
        }

        EditorSceneManager.SaveScene(
            scene,
            folder + "/PokokJawi.unity"
        );

        AssetDatabase.SaveAssets();

        Debug.Log("EXITA: Pokok Jawi scene generated!");
    }
}
