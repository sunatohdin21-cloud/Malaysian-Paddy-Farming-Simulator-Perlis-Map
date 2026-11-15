
using UnityEngine;

namespace ExitaUtara
{
    public class VehicleWorkLights : MonoBehaviour
    {
        [SerializeField] private Light[] frontLights;
        [SerializeField] private Light[] rearLights;

        private bool lightsOn;

        public void ToggleLights()
        {
            lightsOn = !lightsOn;

            SetLights(frontLights, lightsOn);
            SetLights(rearLights, lightsOn);
        }

        private void SetLights(Light[] lights, bool state)
        {
            if (lights == null) return;

            foreach (Light lamp in lights)
            {
                if (lamp != null)
                    lamp.enabled = state;
            }
        }
    }
}
