
using UnityEngine;

namespace ExitaUtara
{
    public class CrawlerSuspension : MonoBehaviour
    {
        [Header("Suspension Settings")]
        public float springStrength = 18000f;
        public float damping = 2200f;
        public float suspensionTravel = 0.35f;
        public float wheelRadius = 0.28f;

        [Header("Ground Detection")]
        public LayerMask groundLayers = ~0;

        private Rigidbody body;

        private void Awake()
        {
            body = GetComponentInParent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (body == null)
                return;

            Vector3 origin = transform.position;
            Vector3 direction = -transform.up;

            if (Physics.Raycast(
                origin,
                direction,
                out RaycastHit hit,
                suspensionTravel + wheelRadius,
                groundLayers))
            {
                float compression =
                    suspensionTravel + wheelRadius - hit.distance;

                compression = Mathf.Clamp(
                    compression, 0f, suspensionTravel);

                float springForce =
                    compression * springStrength;

                float verticalSpeed = Vector3.Dot(
                    body.GetPointVelocity(origin),
                    transform.up);

                float dampingForce =
                    verticalSpeed * damping;

                float totalForce =
                    Mathf.Max(0f, springForce - dampingForce);

                body.AddForceAtPosition(
                    transform.up * totalForce,
                    origin,
                    ForceMode.Force);
            }
        }
    }
}
