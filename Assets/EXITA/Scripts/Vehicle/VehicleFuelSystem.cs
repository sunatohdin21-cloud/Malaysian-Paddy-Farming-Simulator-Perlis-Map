
using UnityEngine;
using UnityEngine.UI;

namespace ExitaUtara
{
    public class VehicleFuelSystem : MonoBehaviour
    {
        [Header("Fuel")]
        [SerializeField] private float maxFuel = 100f;
        [SerializeField] private float currentFuel = 100f;
        [SerializeField] private float consumptionRate = 0.015f;

        [Header("UI")]
        [SerializeField] private Text fuelText;
        [SerializeField] private Slider fuelSlider;

        private void Update()
        {
            if (MobileTractorInput.Throttle > 0f && currentFuel > 0f)
            {
                currentFuel -= consumptionRate * Time.deltaTime;
                currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);
            }

            if (currentFuel <= 0f)
            {
                currentFuel = 0f;
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (fuelText != null)
                fuelText.text = "MINYAK: " +
                    Mathf.CeilToInt(currentFuel) + "%";

            if (fuelSlider != null)
                fuelSlider.value = currentFuel / maxFuel;
        }

        public bool HasFuel()
        {
            return currentFuel > 0f;
        }

        public void Refuel(float amount)
        {
            currentFuel = Mathf.Clamp(
                currentFuel + amount, 0f, maxFuel
            );
        }
    }
}
