
using UnityEngine;

namespace ExitaUtara
{
    public enum VehicleCrawlerType
    {
        Tractor,
        NewHolland1454,
        NewHolland8080
    }

    public class VehicleCrawlerConfig : MonoBehaviour
    {
        [Header("Vehicle Type")]
        public VehicleCrawlerType vehicleType;

        [Header("Crawler Position")]
        public float sideSpacing = 1.8f;
        public float trackLength = 2.4f;
        public float trackHeight = 1.2f;
        public float trackWidth = 0.35f;

        [ContextMenu("Apply Vehicle Crawler Setup")]
        public void ApplySetup()
        {
            bool harvester =
                vehicleType == VehicleCrawlerType.NewHolland1454 ||
                vehicleType == VehicleCrawlerType.NewHolland8080;

            float offset = harvester ? 1.5f : -1.5f;

            SteelCrawlerPair pair =
                GetComponent<SteelCrawlerPair>();

            if (pair == null)
                pair = gameObject.AddComponent<SteelCrawlerPair>();

            pair.spacing = sideSpacing;
            pair.longitudinalOffset = offset;
            pair.trackLength = trackLength;
            pair.trackHeight = trackHeight;
            pair.trackWidth = trackWidth;

            pair.BuildPair();

            Debug.Log(
                vehicleType + " crawler setup applied.");
        }
    }
}
