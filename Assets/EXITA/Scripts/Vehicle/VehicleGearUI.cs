
using UnityEngine;
using UnityEngine.UI;

namespace ExitaUtara
{
    public class VehicleGearUI : MonoBehaviour
    {
        [SerializeField] private VehicleGearSystem gearSystem;
        [SerializeField] private Text gearText;

        public void SetForward()
        {
            if (gearSystem != null)
                gearSystem.GearForward();

            UpdateDisplay();
        }

        public void SetNeutral()
        {
            if (gearSystem != null)
                gearSystem.GearNeutral();

            UpdateDisplay();
        }

        public void SetReverse()
        {
            if (gearSystem != null)
                gearSystem.GearReverse();

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (gearSystem == null || gearText == null)
                return;

            gearText.text = gearSystem.CurrentGear.ToString();
        }

        private void Start()
        {
            UpdateDisplay();
        }
    }
}
