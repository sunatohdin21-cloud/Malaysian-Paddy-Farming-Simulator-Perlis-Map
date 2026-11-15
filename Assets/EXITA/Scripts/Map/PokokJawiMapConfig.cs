
using System;

namespace Exita.Utara.Map
{
    public static class PokokJawiMapConfig
    {
        public const string MapName =
            "EXITA UTARA FARMING SIMULATOR";

        public const string Location =
            "Pokok Jawi, Batu Pahat, Perlis, Malaysia";

        public const string UnityVersion =
            "2022.3.62f1";

        // Saiz sasaran kawasan map dalam meter
        public const float MapWidth = 2000f;
        public const float MapLength = 2000f;
        public const float MaxTerrainHeight = 120f;

        // Kawasan sawah
        public const int PaddyFieldSections = 12;
        public const float PaddyFieldWaterLevel = 0.5f;

        // Sistem tali air dan jalan
        public const bool EnableIrrigationCanals = true;
        public const bool EnableVillageRoads = true;
        public const bool EnableDirtFarmTracks = true;

        // Bangunan dan kawasan kampung
        public const bool EnableMalayVillage = true;
        public const bool EnableRiceMill = true;
        public const bool EnableMachineryWorkshop = true;
        public const bool EnablePaddyCollectionArea = true;

        // Kawasan jentera
        public const bool EnableHarvesterWorkArea = true;
        public const bool EnableHino500TransportArea = true;

        // Peralatan tradisional
        public const bool EnableLongFrontHarvesterFrame = true;

        public static readonly string[] MapFeatures =
        {
            "Sawah padi luas",
            "Parit dan tali air",
            "Jalan kampung berturap",
            "Jalan tanah sawah",
            "Rumah kampung Melayu",
            "Pokok kelapa dan pokok tempatan",
            "Kilang padi",
            "Bengkel jentera",
            "Kawasan pengumpulan padi"
        };
    }
}
