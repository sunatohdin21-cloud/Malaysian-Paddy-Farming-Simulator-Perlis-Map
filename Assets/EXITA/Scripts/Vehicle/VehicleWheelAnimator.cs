
using UnityEngine;

namespace ExitaUtara
{
    public class VehicleWheelAnimator : MonoBehaviour
    {
        [SerializeField] private Rigidbody vehicleBody;
        [SerializeField] private Transform[] wheels;
        [SerializeField] private float rotationMultiplier = 360f;

        private void Update()
        {
            if (vehicleBody == null || wheels == null) return;

            float speed = vehicleBody.velocity.magnitude;

            float direction = Vector3.Dot(
                vehicleBody.velocity,
                transform.forward
            ) >= 0f ? 1f : -1f;

            float rotation = speed *
                rotationMultiplier *
                direction *
                Time.deltaTime;

            foreach (Transform wheel in wheels)
            {
                if (wheel != null)
                    wheel.Rotate(Vector3.right, rotation, Space.Self);
            }
        }
    }
}
