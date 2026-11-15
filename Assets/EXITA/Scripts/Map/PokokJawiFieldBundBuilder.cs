
using UnityEngine;

namespace Exita.Utara.Map
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class PokokJawiFieldBundBuilder : MonoBehaviour
    {
        [Header("Bund Settings")]
        public float bundLength = 150f;
        public float bundWidth = 2f;
        public float bundHeight = 0.8f;

        [ContextMenu("Build Field Bund")]
        public void BuildBund()
        {
            float half = bundWidth * 0.5f;
            float top = half * 0.4f;

            Vector3[] vertices =
            {
                new Vector3(-half, 0f, 0f),
                new Vector3(-top, bundHeight, 0f),
                new Vector3(top, bundHeight, 0f),
                new Vector3(half, 0f, 0f),

                new Vector3(-half, 0f, bundLength),
                new Vector3(-top, bundHeight, bundLength),
                new Vector3(top, bundHeight, bundLength),
                new Vector3(half, 0f, bundLength)
            };

            int[] triangles =
            {
                0, 4, 5, 0, 5, 1,
                1, 5, 6, 1, 6, 2,
                2, 6, 7, 2, 7, 3,
                1, 2, 6, 1, 6, 5,
                0, 1, 2, 0, 2, 3,
                4, 7, 6, 4, 6, 5
            };

            Mesh mesh = new Mesh();
            mesh.name = "PokokJawiFieldBund";
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            GetComponent<MeshFilter>().sharedMesh = mesh;
        }
    }
}
