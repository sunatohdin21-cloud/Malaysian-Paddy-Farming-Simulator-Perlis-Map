
using UnityEngine;

namespace Exita.Utara.Map
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class PokokJawiCanalBuilder : MonoBehaviour
    {
        [Header("Canal Settings")]
        public float canalLength = 500f;
        public float canalWidth = 5f;
        public float canalDepth = 1.5f;

        [Header("Appearance")]
        public Color soilColor = new Color(0.30f, 0.22f, 0.12f);

        [ContextMenu("Build Canal")]
        public void BuildCanal()
        {
            float half = canalWidth * 0.5f;
            float bottom = half * 0.55f;

            Vector3[] vertices =
            {
                new Vector3(-half, 0, 0),
                new Vector3(-bottom, -canalDepth, 0),
                new Vector3(bottom, -canalDepth, 0),
                new Vector3(half, 0, 0),

                new Vector3(-half, 0, canalLength),
                new Vector3(-bottom, -canalDepth, canalLength),
                new Vector3(bottom, -canalDepth, canalLength),
                new Vector3(half, 0, canalLength)
            };

            int[] triangles =
            {
                0, 4, 5, 0, 5, 1,
                1, 5, 6, 1, 6, 2,
                2, 6, 7, 2, 7, 3,
                0, 1, 2, 0, 2, 3,
                4, 7, 6, 4, 6, 5
            };

            Mesh mesh = new Mesh();
            mesh.name = "EXITA_PokokJawi_Canal";
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            MeshFilter filter = GetComponent<MeshFilter>();
            filter.sharedMesh = mesh;

            MeshRenderer renderer = GetComponent<MeshRenderer>();

            Material material = new Material(
                Shader.Find("Standard")
            );

            material.color = soilColor;
            renderer.sharedMaterial = material;

            MeshCollider collider = GetComponent<MeshCollider>();

            if (collider == null)
                collider = gameObject.AddComponent<MeshCollider>();

            collider.sharedMesh = null;
            collider.sharedMesh = mesh;

            Debug.Log("EXITA: Canal mesh generated.");
        }
    }
}
