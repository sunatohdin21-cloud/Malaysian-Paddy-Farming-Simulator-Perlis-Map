
using UnityEngine;

namespace Exita.Utara.Map
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class PokokJawiRoadBuilder : MonoBehaviour
    {
        [Header("Road Settings")]
        public float roadLength = 500f;
        public float roadWidth = 7f;
        public float curveAmount = 12f;
        public int segments = 40;

        [ContextMenu("Build Pokok Jawi Road")]
        public void BuildRoad()
        {
            segments = Mathf.Max(2, segments);

            Vector3[] vertices = new Vector3[(segments + 1) * 2];
            int[] triangles = new int[segments * 6];

            for (int i = 0; i <= segments; i++)
            {
                float t = (float)i / segments;
                float z = t * roadLength;
                float x = Mathf.Sin(t * Mathf.PI * 2f) * curveAmount;

                vertices[i * 2] =
                    new Vector3(x - roadWidth / 2f, 0f, z);

                vertices[i * 2 + 1] =
                    new Vector3(x + roadWidth / 2f, 0f, z);

                if (i < segments)
                {
                    int v = i * 2;
                    int tri = i * 6;

                    triangles[tri] = v;
                    triangles[tri + 1] = v + 2;
                    triangles[tri + 2] = v + 1;

                    triangles[tri + 3] = v + 1;
                    triangles[tri + 4] = v + 2;
                    triangles[tri + 5] = v + 3;
                }
            }

            Mesh mesh = new Mesh();
            mesh.name = "PokokJawiRoadMesh";
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            GetComponent<MeshFilter>().sharedMesh = mesh;

            MeshCollider roadCollider =
                GetComponent<MeshCollider>();

            if (roadCollider == null)
                roadCollider = gameObject.AddComponent<MeshCollider>();

            roadCollider.sharedMesh = mesh;
        }
    }
}
