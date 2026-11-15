
using UnityEngine;

namespace ExitaUtara
{
    public class VehicleEngineStarter : MonoBehaviour
    {
        [SerializeField] private VehicleDrive vehicle;
        [SerializeField] private VehicleFuelSystem fuel;
        
        public bool EngineRunning { get; private set; }

        public void StartEngine()
        {
            if (fuel != null && !fuel.HasFuel())
                return;

            EngineRunning = true;
        }

        public void StopEngine()
        {
            EngineRunning = false;
        }

        public void ToggleEngine()
        {
            if (EngineRunning)
                StopEngine();
            else
                StartEngine();
        }
    }
}
