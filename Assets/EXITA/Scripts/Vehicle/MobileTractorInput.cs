
using UnityEngine;

namespace ExitaUtara
{
    public class MobileTractorInput : MonoBehaviour
    {
        public static float Steering { get; private set; }
        public static float Throttle { get; private set; }
        public static float Brake { get; private set; }

        public void SetSteering(float value)
        {
            Steering = Mathf.Clamp(value, -1f, 1f);
        }

        public void SetThrottle(bool pressed)
        {
            Throttle = pressed ? 1f : 0f;
        }

        public void SetBrake(bool pressed)
        {
            Brake = pressed ? 1f : 0f;
        }

        public void ResetControls()
        {
            Steering = 0f;
            Throttle = 0f;
            Brake = 0f;
        }
    }
}
