
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleDrive : MonoBehaviour
    {
        [Header("Engine")]
        public float acceleration = 5f;
        public float maxSpeed = 12f;
        public float reverseSpeed = 4f;
        public float brakePower = 8f;

        [Header("Steering")]
        public float turnSpeed = 65f;

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

            Vector3 localVelocity =
                transform.InverseTransformDirection(rb.velocity);

            if (throttle > 0f &&
                localVelocity.z < maxSpeed)
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

            if (localVelocity.z > 0.2f ||
                localVelocity.z < -0.2f)
            {
                float direction =
                    localVelocity.z >= 0f ? 1f : -1f;

                Quaternion turn = Quaternion.Euler(
                    0f,
                    steering * turnSpeed *
                    direction * Time.fixedDeltaTime,
                    0f
                );

                rb.MoveRotation(rb.rotation * turn);
            }

            if (localVelocity.z < -reverseSpeed)
            {
                Vector3 velocity = transform.forward * -reverseSpeed;
                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }
        }
    }
}
