
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerRoller : MonoBehaviour
    {
        [Header("Roller Settings")]
        public float radius = 0.22f;
        public float thickness = 0.28f;
        public int rollerCount = 4;
        public float spacing = 0.42f;

        public Color steelColor =
            new Color(0.18f, 0.20f, 0.22f);

        [ContextMenu("Build Crawler Rollers")]
        public void BuildRollers()
        {
            Transform old = transform.Find("RollerAssembly");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("RollerAssembly");
            root.transform.SetParent(transform, false);

            Material steel = new Material(
                Shader.Find("Standard"));

            steel.color = steelColor;
            steel.SetFloat("_Metallic", 0.85f);
            steel.SetFloat("_Glossiness", 0.6f);

            for (int i = 0; i < rollerCount; i++)
            {
                GameObject roller = GameObject.CreatePrimitive(
                    PrimitiveType.Cylinder);

                roller.name = "Steel_Roller_" + i;
                roller.transform.SetParent(root.transform, false);

                roller.transform.localPosition = new Vector3(
                    0f,
                    -i * spacing,
                    0f);

                roller.transform.localRotation =
                    Quaternion.Euler(90f, 0f, 0f);

                roller.transform.localScale = new Vector3(
                    radius * 2f,
                    thickness * 0.5f,
                    radius * 2f);

                roller.GetComponent<MeshRenderer>().sharedMaterial =
                    steel;
            }

            Debug.Log("EXITA: Crawler rollers created.");
        }
    }
}
