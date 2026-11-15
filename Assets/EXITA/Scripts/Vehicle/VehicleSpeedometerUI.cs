
using UnityEngine;
using UnityEngine.UI;

namespace ExitaUtara
{
    public class VehicleSpeedometerUI : MonoBehaviour
    {
        [SerializeField] private Rigidbody vehicleBody;
        [SerializeField] private Text speedText;

        private void Update()
        {
            if (vehicleBody == null || speedText == null)
                return;

            float speed = vehicleBody.velocity.magnitude * 3.6f;

            speedText.text = Mathf.RoundToInt(speed) + " KM/H";
        }
    }
}
