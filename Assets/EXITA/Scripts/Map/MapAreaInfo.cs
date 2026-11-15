
using UnityEngine;

namespace ExitaUtara
{
    [CreateAssetMenu(menuName = "EXITA/Map Area Info")]
    public class MapAreaInfo : ScriptableObject
    {
        [Header("Map Identity")]
        public string mapName =
            "EXITA UTARA FARMING SIMULATOR";

        public string location =
            "Pokok Jawi, Batu Pahat, Perlis";

        [TextArea(3, 6)]
        public string description =
            "Original Malaysian northern countryside map with paddy fields, irrigation canals, kampung roads and rice depot.";

        [Header("World Size")]
        public Vector2 suggestedWorldSize =
            new Vector2(3000f, 3000f);

        [Header("Map Features")]
        public bool paddyFields = true;
        public bool irrigationCanals = true;
        public bool kampungRoads = true;
        public bool dirtFarmTracks = true;
        public bool riceDepot = true;
        public bool tractorWorkshop = true;
        public bool MalayVillage = true;

        [Header("Environment")]
        public float terrainHeight = 30f;
        public float waterLevel = -0.5f;
        public float roadWidth = 7f;
    }
}
