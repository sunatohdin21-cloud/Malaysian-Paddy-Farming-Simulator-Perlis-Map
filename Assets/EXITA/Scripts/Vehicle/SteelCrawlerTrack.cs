
using UnityEngine;

namespace ExitaUtara
{
    public class SteelCrawlerTrack : MonoBehaviour
    {
        [Header("Crawler Dimensions")]
        public float trackLength = 2.4f;
        public float trackHeight = 1.2f;
        public float trackWidth = 0.35f;

        [Header("Steel Chain")]
        public int chainLinks = 36;
        public float linkThickness = 0.09f;
        public float grouserHeight = 0.06f;

        [Header("Appearance")]
        public Color steelColor =
            new Color(0.25f, 0.28f, 0.30f);

        [ContextMenu("Build Steel Crawler")]
        public void BuildCrawler()
        {
            Transform old = transform.Find("SteelLinks");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("SteelLinks");
            root.transform.SetParent(transform, false);

            float halfLength = trackLength * 0.5f;
            float halfHeight = trackHeight * 0.5f;

            Vector2[] corners =
            {
                new Vector2(-halfLength, -halfHeight),
                new Vector2(halfLength, -halfHeight),
                new Vector2(0f, halfHeight)
            };

            Vector2[] path = new Vector2[chainLinks];

            float totalLength = 0f;

            for (int i = 0; i < 3; i++)
                totalLength += Vector2.Distance(
                    corners[i], corners[(i + 1) % 3]);

            for (int i = 0; i < chainLinks; i++)
            {
                float distance = totalLength * i / chainLinks;

                for (int side = 0; side < 3; side++)
                {
                    Vector2 a = corners[side];
                    Vector2 b = corners[(side + 1) % 3];

                    float segmentLength = Vector2.Distance(a, b);

                    if (distance <= segmentLength)
                    {
                        path[i] = Vector2.Lerp(
                            a, b, distance / segmentLength);

                        break;
                    }

                    distance -= segmentLength;
                }
            }

            Material steel = new Material(
                Shader.Find("Standard"));

            steel.color = steelColor;
            steel.SetFloat("_Metallic", 0.85f);
            steel.SetFloat("_Glossiness", 0.65f);

            for (int i = 0; i < chainLinks; i++)
            {
                Vector2 current = path[i];
                Vector2 next = path[(i + 1) % chainLinks];

                Vector2 direction = next - current;

                GameObject link = GameObject.CreatePrimitive(
                    PrimitiveType.Cube);

                link.name = "Steel_Chain_Link_" + i;
                link.transform.SetParent(root.transform, false);

                link.transform.localPosition = new Vector3(
                    (current.x + next.x) * 0.5f,
                    (current.y + next.y) * 0.5f,
                    0f);

                float angle = Mathf.Atan2(
                    direction.y, direction.x) * Mathf.Rad2Deg;

                link.transform.localRotation =
                    Quaternion.Euler(0f, 0f, angle);

                link.transform.localScale = new Vector3(
                    direction.magnitude + 0.025f,
                    linkThickness,
                    trackWidth);

                link.GetComponent<MeshRenderer>().sharedMaterial =
                    steel;

                GameObject grouser = GameObject.CreatePrimitive(
                    PrimitiveType.Cube);

                grouser.name = "Steel_Grouser_" + i;
                grouser.transform.SetParent(link.transform, false);

                grouser.transform.localPosition =
                    new Vector3(0f, 0f, -0.12f);

                grouser.transform.localScale = new Vector3(
                    0.85f,
                    grouserHeight,
                    0.55f);

                grouser.GetComponent<MeshRenderer>().sharedMaterial =
                    steel;
            }

            Debug.Log("EXITA: Triangular steel crawler created.");
        }
    }
}
