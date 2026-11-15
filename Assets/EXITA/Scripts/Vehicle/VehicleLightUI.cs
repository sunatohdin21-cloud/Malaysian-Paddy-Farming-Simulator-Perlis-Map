
using UnityEngine;
using UnityEngine.UI;

namespace ExitaUtara
{
    public class VehicleLightUI : MonoBehaviour
    {
        [SerializeField] private VehicleWorkLights workLights;
        [SerializeField] private Text lightText;

        private bool lightsOn;

        public void ToggleLights()
        {
            if (workLights == null) return;

            workLights.ToggleLights();
            lightsOn = !lightsOn;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (lightText != null)
                lightText.text = lightsOn
                    ? "LAMPU: HIDUP"
                    : "LAMPU: MATI";
        }
    }
}
