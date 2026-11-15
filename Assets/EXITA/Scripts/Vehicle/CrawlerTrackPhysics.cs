
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(Rigidbody))]
    public class CrawlerTrackPhysics : MonoBehaviour
    {
        [Header("Track Power")]
        public float motorTorque = 2500f;
        public float maxSpeed = 12f;
        public float turnPower = 2f;

        [Header("Track Input")]
        [Range(-1f, 1f)]
        public float leftTrackInput;

        [Range(-1f, 1f)]
        public float rightTrackInput;

        [Header("Ground Check")]
        public float groundDistance = 1.5f;
        public LayerMask groundLayers = ~0;

        private Rigidbody body;

        public float SpeedKph =>
            body == null ? 0f : body.velocity.magnitude * 3.6f;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            body.interpolation =
                RigidbodyInterpolation.Interpolate;
        }

        public void SetTrackInput(float left, float right)
        {
            leftTrackInput = Mathf.Clamp(left, -1f, 1f);
            rightTrackInput = Mathf.Clamp(right, -1f, 1f);
        }

        private void FixedUpdate()
        {
            if (body == null)
                return;

            float leftForce = leftTrackInput * motorTorque;
            float rightForce = rightTrackInput * motorTorque;

            Vector3 forward = transform.forward;

            bool grounded = Physics.Raycast(
                transform.position,
                Vector3.down,
                groundDistance,
                groundLayers
            );

            if (!grounded)
                return;

            float average = (leftForce + rightForce) * 0.5f;
            float difference = rightForce - leftForce;

            if (body.velocity.magnitude < maxSpeed ||
                Vector3.Dot(body.velocity, forward) * average < 0f)
            {
                body.AddForce(
                    forward * average,
                    ForceMode.Force
                );
            }

            body.AddTorque(
                Vector3.up * difference * turnPower,
                ForceMode.Force
            );
        }
    }
}
