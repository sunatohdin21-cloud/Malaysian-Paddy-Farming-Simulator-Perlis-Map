
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

        [ContextMenu("Build Paddy Field Layout")]
        public void BuildFields()
        {
            Transform oldFields = transform.Find("PaddyFields");

            if (oldFields != null)
            {
                DestroyImmediate(oldFields.gameObject);
            }

            GameObject root = new GameObject("PaddyFields");
            root.transform.SetParent(transform, false);

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
                        0f,
                        row * (fieldLength + gap)
                    );

                    field.transform.localScale = new Vector3(
                        fieldWidth,
                        1f,
                        fieldLength
                    );
                }
            }
        }
    }
}
