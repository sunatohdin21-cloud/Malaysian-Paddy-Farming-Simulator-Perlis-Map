
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(SteelCrawlerPair))]
    public class CrawlerAssemblyBuilder : MonoBehaviour
    {
        private SteelCrawlerPair crawlerPair;

        [ContextMenu("Build Complete Crawler Assembly")]
        public void BuildAssembly()
        {
            crawlerPair = GetComponent<SteelCrawlerPair>();

            if (crawlerPair == null)
                return;

            crawlerPair.BuildPair();

            Transform pairRoot = transform.Find("CrawlerPair");

            if (pairRoot == null)
                return;

            foreach (Transform track in pairRoot)
            {
                CrawlerHardwareBuilder hardware =
                    track.GetComponent<CrawlerHardwareBuilder>();

                if (hardware == null)
                    hardware = track.gameObject.AddComponent<
                        CrawlerHardwareBuilder>();

                hardware.BuildHardware();
            }

            Debug.Log(
                "EXITA: Crawler assembly created.");
        }
    }
}
