
using UnityEngine;

namespace Exita.Utara.Map
{
    public class PokokJawiTerrainBuilder : MonoBehaviour
    {
        [Header("Map Size")]
        public int mapWidth = 2000;
        public int mapLength = 2000;

        [Header("Terrain")]
        public int heightmapResolution = 513;
        public float terrainHeight = 30f;

        [ContextMenu("Build Pokok Jawi Terrain")]
        public void BuildTerrain()
        {
            TerrainData data = new TerrainData();

            data.heightmapResolution = heightmapResolution;
            data.size = new Vector3(
                mapWidth,
                terrainHeight,
                mapLength
            );

            float[,] heights = new float[
                heightmapResolution,
                heightmapResolution
            ];

            for (int z = 0; z < heightmapResolution; z++)
            {
                for (int x = 0; x < heightmapResolution; x++)
                {
                    heights[z, x] = 0.015f;
                }
            }

            data.SetHeights(0, 0, heights);

            Transform oldTerrain =
                transform.Find("Pokok Jawi Paddy Terrain");

            if (oldTerrain != null)
            {
                DestroyImmediate(oldTerrain.gameObject);
            }

            GameObject terrainObject =
                Terrain.CreateTerrainGameObject(data);

            terrainObject.name = "Pokok Jawi Paddy Terrain";
            terrainObject.transform.SetParent(transform, false);
            terrainObject.transform.localPosition = Vector3.zero;

            Debug.Log("EXITA: Pokok Jawi terrain created.");
        }
    }
}
