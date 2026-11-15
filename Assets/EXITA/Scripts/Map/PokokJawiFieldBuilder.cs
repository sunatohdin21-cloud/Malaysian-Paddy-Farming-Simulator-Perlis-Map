
using UnityEngine;

namespace Exita.Utara.Map
{
    public class PokokJawiFieldBuilder : MonoBehaviour
    {
        [Header("Paddy Field Settings")]
        public int rows = 4;
        public int columns = 5;
        public float fieldWidth = 100f;
        public float fieldLength = 150f;
        public float gap = 12f;

        [Header("Field Appearance")]
        public Color soilColor = new Color(0.32f, 0.25f, 0.13f);
        public float surfaceHeight = 0.05f;

        [ContextMenu("Build Paddy Field Layout")]
        public void BuildFields()
        {
            Transform oldFields = transform.Find("PaddyFields");

            if (oldFields != null)
                DestroyImmediate(oldFields.gameObject);

            GameObject root = new GameObject("PaddyFields");
            root.transform.SetParent(transform, false);

            Material soilMaterial = new Material(
                Shader.Find("Standard")
            );

            soilMaterial.color = soilColor;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    GameObject field = new GameObject(
                        "PaddyField_" + row + "_" + col
                    );

                    field.transform.SetParent(root.transform, false);

                    field.transform.localPosition = new Vector3(
                        col * (fieldWidth + gap),
                        surfaceHeight,
                        row * (fieldLength + gap)
                    );

                    Mesh mesh = new Mesh();
                    mesh.name = "Paddy Field Surface";

                    mesh.vertices = new Vector3[]
                    {
                        new Vector3(0, 0, 0),
                        new Vector3(fieldWidth, 0, 0),
                        new Vector3(0, 0, fieldLength),
                        new Vector3(fieldWidth, 0, fieldLength)
                    };

                    mesh.triangles = new int[]
                    {
                        0, 2, 1,
                        2, 3, 1
                    };

                    mesh.RecalculateNormals();

                    MeshFilter filter =
                        field.AddComponent<MeshFilter>();

                    filter.sharedMesh = mesh;

                    MeshRenderer renderer =
                        field.AddComponent<MeshRenderer>();

                    renderer.sharedMaterial = soilMaterial;
                }
            }

            Debug.Log("EXITA: 20 paddy field surfaces created.");
        }
    }
}
