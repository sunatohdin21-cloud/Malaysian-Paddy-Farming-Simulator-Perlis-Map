
using UnityEngine;

namespace Exita.Utara.Map
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class PokokJawiCanalWater : MonoBehaviour
    {
        [Header("Water Settings")]
        public float waterLength = 500f;
        public float waterWidth = 2.5f;
        public float waterLevel = -0.5f;
        public float waveHeight = 0.04f;

        [Header("Water Appearance")]
        public Color waterColor =
            new Color(0.08f, 0.35f, 0.32f, 1f);

        [ContextMenu("Build Canal Water")]
        public void BuildWater()
        {
            float wave = waveHeight;

            Vector3[] vertices =
            {
                new Vector3(-waterWidth / 2f, waterLevel, 0f),
                new Vector3(waterWidth / 2f, waterLevel + wave, 0f),
                new Vector3(-waterWidth / 2f, waterLevel, waterLength),
                new Vector3(waterWidth / 2f, waterLevel + wave, waterLength)
            };

            int[] triangles =
            {
                0, 2, 1,
                1, 2, 3
            };

            Mesh mesh = new Mesh();
            mesh.name = "EXITA_PokokJawi_Water";
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            GetComponent<MeshFilter>().sharedMesh = mesh;

            Material material = new Material(
                Shader.Find("Standard")
            );

            material.color = waterColor;
            material.SetFloat("_Glossiness", 0.85f);

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.sharedMaterial = material;

            Debug.Log("EXITA: Canal water surface created.");
        }
    }
}
