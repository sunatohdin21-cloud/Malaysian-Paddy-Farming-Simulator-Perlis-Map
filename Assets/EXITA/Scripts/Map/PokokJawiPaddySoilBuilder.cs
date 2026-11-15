
using UnityEngine;

namespace Exita.Utara.Map
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class PokokJawiPaddySoilBuilder : MonoBehaviour
    {
        [Header("Paddy Soil")]
        public float soilWidth = 100f;
        public float soilLength = 150f;
        public int subdivisions = 30;
        public float unevenness = 0.12f;

        [Header("Muddy Appearance")]
        public Color mudColor =
            new Color(0.25f, 0.19f, 0.12f);

        [Range(0f, 1f)]
        public float wetness = 0.45f;

        [ContextMenu("Build Paddy Soil")]
        public void BuildSoil()
        {
            subdivisions = Mathf.Max(2, subdivisions);

            int side = subdivisions + 1;

            Vector3[] vertices = new Vector3[side * side];

            int[] triangles =
                new int[subdivisions * subdivisions * 6];

            for (int z = 0; z < side; z++)
            {
                for (int x = 0; x < side; x++)
                {
                    float px =
                        (float)x / subdivisions * soilWidth;

                    float pz =
                        (float)z / subdivisions * soilLength;

                    float height =
                        Mathf.Sin(px * 0.12f) *
                        Mathf.Cos(pz * 0.09f) *
                        unevenness;

                    vertices[z * side + x] =
                        new Vector3(px, height, pz);
                }
            }

            int index = 0;

            for (int z = 0; z < subdivisions; z++)
            {
                for (int x = 0; x < subdivisions; x++)
                {
                    int a = z * side + x;
                    int b = a + 1;
                    int c = a + side;
                    int d = c + 1;

                    triangles[index++] = a;
                    triangles[index++] = c;
                    triangles[index++] = b;

                    triangles[index++] = b;
                    triangles[index++] = c;
                    triangles[index++] = d;
                }
            }

            Mesh mesh = new Mesh();
            mesh.name = "EXITA_PokokJawi_MuddySoil";
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            GetComponent<MeshFilter>().sharedMesh = mesh;

            Material material = new Material(
                Shader.Find("Standard")
            );

            material.color = mudColor;
            material.SetFloat(
                "_Glossiness",
                wetness
            );

            GetComponent<MeshRenderer>().sharedMaterial =
                material;

            Debug.Log("EXITA: Muddy paddy soil created.");
        }
    }
}
