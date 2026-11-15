
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(CrawlerTrackPhysics))]
    public class CrawlerDriveController : MonoBehaviour
    {
        private CrawlerTrackPhysics crawler;

        private float throttle;
        private float steering;
        private float brake;

        [Header("Driving Settings")]
        public float steeringSensitivity = 1f;
        public float brakeDrag = 5f;

        public float SpeedKph =>
            crawler == null ? 0f : crawler.SpeedKph;

        private void Awake()
        {
            crawler = GetComponent<CrawlerTrackPhysics>();
        }

        public void SetThrottle(float value)
        {
            throttle = Mathf.Clamp(value, -1f, 1f);
            UpdateTracks();
        }

        public void SetSteering(float value)
        {
            steering = Mathf.Clamp(value, -1f, 1f);
            UpdateTracks();
        }

        public void SetBrake(float value)
        {
            brake = Mathf.Clamp01(value);

            if (crawler != null && brake > 0f)
                crawler.SetTrackInput(0f, 0f);
        }

        private void UpdateTracks()
        {
            if (crawler == null)
                return;

            float turn = steering * steeringSensitivity;

            float left = throttle - turn;
            float right = throttle + turn;

            float highest = Mathf.Max(
                1f,
                Mathf.Abs(left),
                Mathf.Abs(right));

            left /= highest;
            right /= highest;

            crawler.SetTrackInput(left, right);
        }

        private void FixedUpdate()
        {
            if (crawler == null)
                return;

            if (brake > 0f)
            {
                crawler.SetTrackInput(0f, 0f);

                Rigidbody body = GetComponent<Rigidbody>();

                if (body != null)
                    body.velocity = Vector3.Lerp(
                        body.velocity,
                        Vector3.zero,
                        Time.fixedDeltaTime * brakeDrag);
            }
        }
    }
}
