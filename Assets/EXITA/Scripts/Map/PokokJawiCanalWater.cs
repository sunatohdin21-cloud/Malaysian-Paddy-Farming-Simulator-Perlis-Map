
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

        [ContextMenu("Build Canal Water")]
        public void BuildWater()
        {
            Vector3[] vertices =
            {
                new Vector3(-waterWidth / 2f, waterLevel, 0f),
                new Vector3(waterWidth / 2f, waterLevel, 0f),
                new Vector3(-waterWidth / 2f, waterLevel, waterLength),
                new Vector3(waterWidth / 2f, waterLevel, waterLength)
            };

            int[] triangles =
            {
                0, 2, 1,
                1, 2, 3
            };

            Mesh mesh = new Mesh();
            mesh.name = "PokokJawiWaterSurface";
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            GetComponent<MeshFilter>().sharedMesh = mesh;

            MeshCollider oldCollider =
                GetComponent<MeshCollider>();

            if (oldCollider != null)
                DestroyImmediate(oldCollider);

        }
    }
}
