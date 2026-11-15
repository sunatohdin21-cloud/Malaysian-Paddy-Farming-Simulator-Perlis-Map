
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerTrackTension : MonoBehaviour
    {
        [Header("Track Tension")]
        [Range(0f, 1f)]
        public float tension = 0.75f;

        public float minimumLength = 2.0f;
        public float maximumLength = 2.8f;

        [Header("Track Components")]
        public SteelCrawlerTrack crawlerTrack;

        private float originalLength;

        private void Awake()
        {
            if (crawlerTrack != null)
                originalLength = crawlerTrack.trackLength;
        }

        public void SetTension(float value)
        {
            tension = Mathf.Clamp01(value);
            ApplyTension();
        }

        [ContextMenu("Apply Track Tension")]
        public void ApplyTension()
        {
            if (crawlerTrack == null)
                return;

            crawlerTrack.trackLength = Mathf.Lerp(
                minimumLength,
                maximumLength,
                tension
            );

            crawlerTrack.BuildCrawler();

            Debug.Log(
                "EXITA: Track tension set to " + tension);
        }
    }
}
