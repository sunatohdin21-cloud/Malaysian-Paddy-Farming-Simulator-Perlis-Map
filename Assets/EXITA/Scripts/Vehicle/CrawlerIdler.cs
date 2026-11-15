
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerIdler : MonoBehaviour
    {
        [Header("Idler Settings")]
        public float radius = 0.42f;
        public float thickness = 0.28f;

        public Color steelColor =
            new Color(0.28f, 0.30f, 0.32f);

        [ContextMenu("Build Front Idler")]
        public void BuildIdler()
        {
            Transform old = transform.Find("IdlerBody");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("IdlerBody");
            root.transform.SetParent(transform, false);

            Material steel = new Material(
                Shader.Find("Standard"));

            steel.color = steelColor;
            steel.SetFloat("_Metallic", 0.9f);
            steel.SetFloat("_Glossiness", 0.65f);

            GameObject wheel = GameObject.CreatePrimitive(
                PrimitiveType.Cylinder);

            wheel.name = "Front_Steel_Idler";
            wheel.transform.SetParent(root.transform, false);

            wheel.transform.localRotation =
                Quaternion.Euler(90f, 0f, 0f);

            wheel.transform.localScale = new Vector3(
                radius * 2f,
                thickness * 0.5f,
                radius * 2f);

            wheel.GetComponent<MeshRenderer>().sharedMaterial =
                steel;

            Debug.Log("EXITA: Front idler created.");
        }
    }
}
