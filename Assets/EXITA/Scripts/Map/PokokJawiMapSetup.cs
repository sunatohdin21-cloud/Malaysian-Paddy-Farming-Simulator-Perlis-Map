
using UnityEngine;

namespace Exita.Utara.Map
{
    public class PokokJawiMapSetup : MonoBehaviour
    {
        [ContextMenu("Build Pokok Jawi Map")]
        public void BuildMap()
        {
            CreateBuilder("Terrain",
                typeof(PokokJawiTerrainBuilder));

            CreateBuilder("Paddy Soil",
                typeof(PokokJawiPaddySoilBuilder));

            CreateBuilder("Paddy Fields",
                typeof(PokokJawiFieldBuilder));

            CreateBuilder("Canals",
                typeof(PokokJawiCanalBuilder));

            CreateBuilder("Canal Water",
                typeof(PokokJawiCanalWater));

            CreateBuilder("Field Bunds",
                typeof(PokokJawiFieldBundBuilder));

            CreateBuilder("Village Roads",
                typeof(PokokJawiRoadBuilder));

            Debug.Log(
                "Pokok Jawi map components created. " +
                "Run each builder to generate its mesh."
            );
        }

        private void CreateBuilder(
            string objectName,
            System.Type builderType)
        {
            Transform existing = transform.Find(objectName);

            if (existing != null)
                return;

            GameObject item = new GameObject(objectName);
            item.transform.SetParent(transform, false);
            item.AddComponent(builderType);
        }
    }
}
