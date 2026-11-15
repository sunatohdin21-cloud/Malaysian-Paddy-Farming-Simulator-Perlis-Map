
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerHardwareBuilder : MonoBehaviour
    {
        [Header("Crawler Size")]
        public float trackLength = 2.4f;
        public float trackHeight = 1.2f;
        public float trackWidth = 0.35f;

        [Header("Hardware")]
        public float wheelRadius = 0.28f;
        public int rollerCount = 3;

        private Material steel;

        [ContextMenu("Build Crawler Hardware")]
        public void BuildHardware()
        {
            Transform old = transform.Find("CrawlerHardware");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("CrawlerHardware");
            root.transform.SetParent(transform, false);

            steel = new Material(Shader.Find("Standard"));
            steel.color = new Color(0.25f, 0.28f, 0.30f);
            steel.SetFloat("_Metallic", 0.9f);
            steel.SetFloat("_Glossiness", 0.65f);

            float halfLength = trackLength * 0.5f;
            float bottom = -trackHeight * 0.5f;

            CreateWheel(root.transform,
                "Drive Sprocket",
                new Vector3(-halfLength, bottom, 0f),
                wheelRadius * 0.9f);

            CreateWheel(root.transform,
                "Front Idler",
                new Vector3(halfLength, bottom, 0f),
                wheelRadius);

            for (int i = 0; i < rollerCount; i++)
            {
                float t = (i + 1f) / (rollerCount + 1f);

                float x = Mathf.Lerp(
                    -halfLength * 0.65f,
                    halfLength * 0.65f,
                    t);

                CreateWheel(root.transform,
                    "Road Roller " + (i + 1),
                    new Vector3(x, bottom + 0.12f, 0f),
                    wheelRadius * 0.65f);
            }

            Debug.Log("EXITA: Crawler hardware installed.");
        }

        private void CreateWheel(
            Transform parent,
            string wheelName,
            Vector3 position,
            float radius)
        {
            GameObject wheel = GameObject.CreatePrimitive(
                PrimitiveType.Cylinder);

            wheel.name = wheelName;
            wheel.transform.SetParent(parent, false);
            wheel.transform.localPosition = position;

            wheel.transform.localRotation =
                Quaternion.Euler(90f, 0f, 0f);

            wheel.transform.localScale = new Vector3(
                radius * 2f,
                trackWidth * 0.45f,
                radius * 2f);

            wheel.GetComponent<MeshRenderer>().sharedMaterial =
                steel;
        }
    }
}
