
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

        [Header("Systems")]
        public VehicleFuelSystem fuelSystem;
        public VehicleEngineStarter engineStarter;

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

            bool engineOn = engineStarter != null &&
                            engineStarter.EngineRunning;

            bool hasFuel = fuelSystem == null ||
                           fuelSystem.HasFuel();

            Vector3 velocity =
                transform.InverseTransformDirection(rb.velocity);

            if (engineOn && hasFuel &&
                throttle > 0f && velocity.z < maxSpeed)
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

                Quaternion turn = Quaternion.Euler(
                    0f,
                    steering * turnSpeed *
                    direction * Time.fixedDeltaTime,
                    0f
                );

                rb.MoveRotation(rb.rotation * turn);
            }
        }
    }
}
