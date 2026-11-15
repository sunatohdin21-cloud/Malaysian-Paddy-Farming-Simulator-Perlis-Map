
using UnityEngine;

namespace ExitaUtara
{
    public class SteelCrawlerPair : MonoBehaviour
    {
        [Header("Crawler Position")]
        public float spacing = 1.8f;

        // Traktor: belakang (-1.5)
        // Harvester: depan (1.5)
        public float longitudinalOffset = -1.5f;

        [Header("Crawler Dimensions")]
        public float trackLength = 2.4f;
        public float trackHeight = 1.2f;
        public float trackWidth = 0.35f;
        public int chainLinks = 36;

        [ContextMenu("Build Left And Right Crawlers")]
        public void BuildPair()
        {
            Transform old = transform.Find("CrawlerPair");

            if (old != null)
                DestroyImmediate(old.gameObject);

            GameObject root = new GameObject("CrawlerPair");
            root.transform.SetParent(transform, false);

            CreateTrack(root.transform,
                "Left Steel Crawler", -spacing * 0.5f);

            CreateTrack(root.transform,
                "Right Steel Crawler", spacing * 0.5f);

            Debug.Log("EXITA: Twin steel crawlers created.");
        }

        private void CreateTrack(
            Transform parent,
            string trackName,
            float xPosition)
        {
            GameObject track = new GameObject(trackName);
            track.transform.SetParent(parent, false);

            track.transform.localPosition = new Vector3(
                xPosition, 0f, longitudinalOffset);

            track.transform.localRotation =
                Quaternion.Euler(0f, 90f, 0f);

            SteelCrawlerTrack crawler =
                track.AddComponent<SteelCrawlerTrack>();

            crawler.trackLength = trackLength;
            crawler.trackHeight = trackHeight;
            crawler.trackWidth = trackWidth;
            crawler.chainLinks = chainLinks;

            crawler.BuildCrawler();
        }
    }
}
