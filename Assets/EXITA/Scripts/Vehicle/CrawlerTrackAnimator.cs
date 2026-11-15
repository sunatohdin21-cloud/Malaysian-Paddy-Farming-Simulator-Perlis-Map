
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerTrackAnimator : MonoBehaviour
    {
        [Header("Animation")]
        public float animationSpeed = 2f;
        public float linkSpacing = 0.15f;

        [Header("Movement")]
        public bool reverseDirection;

        private Transform linksRoot;
        private Transform[] links;
        private float movement;

        private void Awake()
        {
            FindLinks();
        }

        private void FindLinks()
        {
            linksRoot = transform.Find("SteelLinks");

            if (linksRoot == null)
                return;

            int count = linksRoot.childCount;
            links = new Transform[count];

            for (int i = 0; i < count; i++)
                links[i] = linksRoot.GetChild(i);
        }

        private void Update()
        {
            if (links == null || links.Length == 0)
                return;

            float direction = reverseDirection ? -1f : 1f;

            movement += Time.deltaTime *
                animationSpeed * direction;

            float offset = movement % linkSpacing;

            for (int i = 0; i < links.Length; i++)
            {
                if (links[i] == null)
                    continue;

                Vector3 position =
                    links[i].localPosition;

                position.z = offset;

                links[i].localPosition = position;
            }
        }
    }
}
