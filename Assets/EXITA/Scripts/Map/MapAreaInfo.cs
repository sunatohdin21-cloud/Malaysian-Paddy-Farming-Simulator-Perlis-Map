using UnityEngine;

namespace ExitaUtara
{
    // Metadata for the planned original Perlis-inspired map.
    // This does not create accurate real-world roads or terrain by itself.
    [CreateAssetMenu(menuName = "EXITA/Map Area Info")]
    public class MapAreaInfo : ScriptableObject
    {
        public string mapName = "Pokok Jawi - Batu Pahat, Perlis";
        [TextArea] public string description =
            "Original rural map concept: paddy fields, irrigation canals, kampung roads and a rice depot.";
        public Vector2 suggestedWorldSize = new Vector2(3000f, 3000f);
    }
}
