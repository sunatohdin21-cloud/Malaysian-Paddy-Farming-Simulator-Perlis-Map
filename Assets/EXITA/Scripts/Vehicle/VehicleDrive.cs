
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleDrive : MonoBehaviour
    {
        public float acceleration = 5f;
        public float maxSpeed = 12f;
        public float reverseSpeed = 4f;
        public float brakePower = 8f;
        public float turnSpeed = 65f;

        public VehicleFuelSystem fuelSystem;
        public VehicleEngineStarter engineStarter;
        public VehicleGearSystem gearSystem;

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

            int gear = gearSystem != null
                ? gearSystem.GetGearValue() : 0;

            float speedLimit = gear < 0
                ? reverseSpeed : maxSpeed;

            Vector3 localVelocity =
                transform.InverseTransformDirection(rb.velocity);

            if (engineOn && hasFuel && gear != 0 &&
                throttle > 0f &&
                localVelocity.z * gear < speedLimit)
            {
                rb.AddForce(
                    transform.forward * gear * acceleration,
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

            if (Mathf.Abs(localVelocity.z) > 0.2f)
            {
                float direction = localVelocity.z >= 0f ? 1f : -1f;

                rb.MoveRotation(
                    rb.rotation * Quaternion.Euler(
                        0f,
                        steering * turnSpeed *
                        direction * Time.fixedDeltaTime,
                        0f
                    )
                );
            }
        }
    }
}
