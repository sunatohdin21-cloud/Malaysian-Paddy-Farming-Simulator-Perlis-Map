
using UnityEngine;
using UnityEngine.UI;

namespace ExitaUtara
{
    public class VehicleEngineUI : MonoBehaviour
    {
        [SerializeField] private VehicleEngineStarter engine;
        [SerializeField] private Text engineText;

        public void ToggleEngine()
        {
            if (engine == null) return;

            engine.ToggleEngine();
            UpdateDisplay();
        }

        private void Update()
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (engine == null || engineText == null)
                return;

            engineText.text = engine.EngineRunning
                ? "ENJIN: HIDUP"
                : "ENJIN: MATI";
        }
    }
}
