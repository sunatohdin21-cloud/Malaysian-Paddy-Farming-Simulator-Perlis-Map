
using System.Reflection;
using UnityEngine;

namespace Exita.Utara.Map
{
    public class PokokJawiMapSetup : MonoBehaviour
    {
        [ContextMenu("Build Pokok Jawi Map")]
        public void BuildMap()
        {
            BuildPart("Terrain", typeof(PokokJawiTerrainBuilder));
            BuildPart("Paddy Soil", typeof(PokokJawiPaddySoilBuilder));
            BuildPart("Paddy Fields", typeof(PokokJawiFieldBuilder));
            BuildPart("Canals", typeof(PokokJawiCanalBuilder));
            BuildPart("Canal Water", typeof(PokokJawiCanalWater));
            BuildPart("Field Bunds", typeof(PokokJawiFieldBundBuilder));
            BuildPart("Village Roads", typeof(PokokJawiRoadBuilder));

            Debug.Log("EXITA: Pokok Jawi map build completed.");
        }

        private void BuildPart(string objectName, System.Type builderType)
        {
            Transform existing = transform.Find(objectName);

            GameObject item;

            if (existing != null)
            {
                item = existing.gameObject;
            }
            else
            {
                item = new GameObject(objectName);
                item.transform.SetParent(transform, false);
            }

            Component builder = item.GetComponent(builderType);

            if (builder == null)
                builder = item.AddComponent(builderType);

            MethodInfo[] methods = builderType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic
            );

            foreach (MethodInfo method in methods)
            {
                if (method.Name.StartsWith("Build") &&
                    method.GetParameters().Length == 0 &&
                    method.ReturnType == typeof(void))
                {
                    method.Invoke(builder, null);
                    break;
                }
            }
        }
    }
}
