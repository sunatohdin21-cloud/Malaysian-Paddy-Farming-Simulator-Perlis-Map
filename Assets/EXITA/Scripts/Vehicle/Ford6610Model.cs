
using UnityEngine;

namespace ExitaUtara
{
    public class Ford6610Model : MonoBehaviour
    {
        [Header("Body Dimensions")]
        public float bodyLength = 3.2f;
        public float bodyWidth = 1.65f;
        public float bodyHeight = 1.15f;

        [Header("Front Tyres")]
        public float frontWheelRadius = 0.48f;
        public float frontWheelWidth = 0.28f;

        [Header("Rear Crawler")]
        public float crawlerSpacing = 1.8f;

        [Header("Appearance")]
        public Color bodyColor =
            new Color(0.05f, 0.20f, 0.65f);

        [ContextMenu("Build Ford 6610 Body")]
        public void BuildModel()
        {
            Transform old = transform.Find("Ford6610_Body");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("Ford6610_Body");
            root.transform.SetParent(transform, false);

            Material blue = CreateMaterial(bodyColor);
            Material black = CreateMaterial(Color.black);
            Material rubber = CreateMaterial(
                new Color(0.08f, 0.08f, 0.08f));

            CreateCube(root.transform, "Engine Bonnet",
                new Vector3(0f, 1.25f, 0.55f),
                new Vector3(1.15f, 0.75f, 1.65f), blue);

            CreateCube(root.transform, "Chassis",
                new Vector3(0f, 0.75f, -0.15f),
                new Vector3(1.25f, 0.35f, 2.7f), black);

            CreateCube(root.transform, "Driver Platform",
                new Vector3(0f, 1.2f, -0.85f),
                new Vector3(1.35f, 0.25f, 0.85f), blue);

            CreateCube(root.transform, "Seat",
                new Vector3(0f, 1.65f, -0.85f),
                new Vector3(0.48f, 0.18f, 0.48f),
                black);

            CreateFrontWheel(root.transform,
                "Front Left Tyre",
                new Vector3(-0.9f, 0.48f, 1.0f), rubber);

            CreateFrontWheel(root.transform,
                "Front Right Tyre",
                new Vector3(0.9f, 0.48f, 1.0f), rubber);

            CreateCube(root.transform, "Exhaust Pipe",
                new Vector3(-0.38f, 2.05f, 0.45f),
                new Vector3(0.09f, 1.1f, 0.09f), black);

            CreateCube(root.transform, "Roof Canopy",
                new Vector3(0f, 2.55f, -0.9f),
                new Vector3(1.65f, 0.12f, 1.45f), blue);

            GameObject crawlerRoot =
                new GameObject("Rear Steel Crawlers");

            crawlerRoot.transform.SetParent(root.transform, false);

            SteelCrawlerPair pair =
                crawlerRoot.AddComponent<SteelCrawlerPair>();

            pair.spacing = crawlerSpacing;
            pair.longitudinalOffset = -1.25f;
            pair.trackLength = 2.4f;
            pair.trackHeight = 1.2f;
            pair.trackWidth = 0.35f;
            pair.BuildPair();

            Debug.Log(
                "EXITA: Ford 6610 base model created.");
        }

        private void CreateFrontWheel(
            Transform parent,
            string wheelName,
            Vector3 position,
            Material material)
        {
            GameObject wheel = GameObject.CreatePrimitive(
                PrimitiveType.Cylinder);

            wheel.name = wheelName;
            wheel.transform.SetParent(parent, false);
            wheel.transform.localPosition = position;

            wheel.transform.localRotation =
                Quaternion.Euler(0f, 0f, 90f);

            wheel.transform.localScale = new Vector3(
                frontWheelWidth,
                frontWheelRadius,
                frontWheelRadius);

            wheel.GetComponent<MeshRenderer>().sharedMaterial =
                material;
        }

        private void CreateCube(
            Transform parent,
            string objectName,
            Vector3 position,
            Vector3 scale,
            Material material)
        {
            GameObject part = GameObject.CreatePrimitive(
                PrimitiveType.Cube);

            part.name = objectName;
            part.transform.SetParent(parent, false);
            part.transform.localPosition = position;
            part.transform.localScale = scale;

            part.GetComponent<MeshRenderer>().sharedMaterial =
                material;
        }

        private Material CreateMaterial(Color color)
        {
            Material material =
                new Material(Shader.Find("Standard"));

            material.color = color;
            return material;
        }
    }
}
