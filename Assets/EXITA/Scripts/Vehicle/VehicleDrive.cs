
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleDrive : MonoBehaviour
    {
        [Header("Engine")]
        public float acceleration = 5f;
        public float maxSpeed = 12f;
        public float brakePower = 8f;

        [Header("Steering")]
        public float turnSpeed = 65f;

        [Header("Fuel")]
        public VehicleFuelSystem fuelSystem;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.mass = 2500f;
            rb.drag = 0.5f;
            rb.angularDrag = 3f;
        }

        private void FixedUpdate()
        {
            float throttle = MobileTractorInput.Throttle;
            float brake = MobileTractorInput.Brake;
            float steering = MobileTractorInput.Steering;

            bool hasFuel = fuelSystem == null ||
                           fuelSystem.HasFuel();

            Vector3 velocity =
                transform.InverseTransformDirection(rb.velocity);

            if (throttle > 0f && hasFuel &&
                velocity.z < maxSpeed)
            {
                rb.AddForce(
                    transform.forward * acceleration,
                    ForceMode.Acceleration
                );
            }

            if (brake > 0f)
            {
                rb.AddForce(
                    -rb.velocity.normalized * brakePower,
                    ForceMode.Acceleration
                );
            }

            if (Mathf.Abs(velocity.z) > 0.2f)
            {
                float direction = velocity.z >= 0f ? 1f : -1f;

                Quaternion rotation = Quaternion.Euler(
                    0f,
                    steering * turnSpeed *
                    direction * Time.fixedDeltaTime,
                    0f
                );

                rb.MoveRotation(rb.rotation * rotation);
            }
        }
    }
}
