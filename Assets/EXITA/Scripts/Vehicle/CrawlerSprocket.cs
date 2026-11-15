
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerSprocket : MonoBehaviour
    {
        [Header("Sprocket Settings")]
        public float radius = 0.38f;
        public float thickness = 0.22f;
        public int teeth = 12;

        public Color steelColor =
            new Color(0.22f, 0.24f, 0.26f);

        [ContextMenu("Build Steel Sprocket")]
        public void BuildSprocket()
        {
            Transform old = transform.Find("SprocketBody");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("SprocketBody");
            root.transform.SetParent(transform, false);

            Material steel = new Material(
                Shader.Find("Standard"));

            steel.color = steelColor;
            steel.SetFloat("_Metallic", 0.9f);
            steel.SetFloat("_Glossiness", 0.7f);

            GameObject wheel = GameObject.CreatePrimitive(
                PrimitiveType.Cylinder);

            wheel.name = "SteelDriveWheel";
            wheel.transform.SetParent(root.transform, false);

            wheel.transform.localRotation =
                Quaternion.Euler(90f, 0f, 0f);

            wheel.transform.localScale = new Vector3(
                radius * 2f,
                thickness * 0.5f,
                radius * 2f);

            wheel.GetComponent<MeshRenderer>().sharedMaterial =
                steel;

            for (int i = 0; i < teeth; i++)
            {
                float angle = i * 360f / teeth;
                float radians = angle * Mathf.Deg2Rad;

                GameObject tooth = GameObject.CreatePrimitive(
                    PrimitiveType.Cube);

                tooth.name = "Sprocket_Tooth_" + i;
                tooth.transform.SetParent(root.transform, false);

                tooth.transform.localPosition = new Vector3(
                    Mathf.Cos(radians) * radius,
                    0f,
                    Mathf.Sin(radians) * radius);

                tooth.transform.localRotation =
                    Quaternion.Euler(0f, -angle, 0f);

                tooth.transform.localScale = new Vector3(
                    0.16f, thickness, 0.12f);

                tooth.GetComponent<MeshRenderer>().sharedMaterial =
                    steel;
            }

            Debug.Log("EXITA: Steel sprocket created.");
        }
    }
}
