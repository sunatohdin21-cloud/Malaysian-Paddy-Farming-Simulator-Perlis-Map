using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleDrive : MonoBehaviour
    {
        [Header("Drive tuning")]
        [SerializeField] private float motorTorque = 1800f;
        [SerializeField] private float brakeTorque = 2600f;
        [SerializeField] private float maxSpeedKph = 45f;
        [SerializeField] private float steeringDegrees = 28f;
        [SerializeField] private float steeringResponse = 3f;

        [Header("Wheel colliders")]
        [SerializeField] private WheelCollider[] poweredWheels;
        [SerializeField] private WheelCollider[] steeringWheels;
        [SerializeField] private WheelCollider[] allWheels;

        private Rigidbody body;
        private float throttle;
        private float steering;
        private float brake;

        public float SpeedKph => body == null ? 0f : body.velocity.magnitude * 3.6f;
        public float EngineLoad => Mathf.Clamp01(Mathf.Abs(throttle) * 0.8f + brake * 0.2f);
        public float Throttle => throttle;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.centerOfMass = new Vector3(0f, -0.45f, 0f);
        }

        // Connect these methods to the mobile HUD buttons/joystick.
        public void SetThrottle(float value) => throttle = Mathf.Clamp(value, -1f, 1f);
        public void SetSteering(float value) => steering = Mathf.Clamp(value, -1f, 1f);
        public void SetBrake(float value) => brake = Mathf.Clamp01(value);

        private void FixedUpdate()
        {
            float speedFactor = Mathf.Clamp01(1f - SpeedKph / Mathf.Max(1f, maxSpeedKph));
            foreach (var wheel in poweredWheels)
                if (wheel != null)
                    wheel.motorTorque = throttle * motorTorque * speedFactor;

            foreach (var wheel in steeringWheels)
                if (wheel != null)
                    wheel.steerAngle = Mathf.Lerp(wheel.steerAngle,
                        steering * steeringDegrees, Time.fixedDeltaTime * steeringResponse);

            foreach (var wheel in allWheels)
                if (wheel != null)
                    wheel.brakeTorque = brake * brakeTorque;
        }

        private void OnDisable()
        {
            if (poweredWheels != null)
                foreach (var wheel in poweredWheels)
                    if (wheel != null) wheel.motorTorque = 0f;
        }
    }
}
