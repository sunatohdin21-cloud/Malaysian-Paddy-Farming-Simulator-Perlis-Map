
using UnityEngine;
using UnityEngine.EventSystems;

namespace ExitaUtara
{
    public class MobileTractorButton : MonoBehaviour,
        IPointerDownHandler, IPointerUpHandler
    {
        public enum ControlType
        {
            Left,
            Right,
            Throttle,
            Brake
        }

        [SerializeField] private ControlType control;
        [SerializeField] private MobileTractorInput input;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (input == null) return;

            switch (control)
            {
                case ControlType.Left:
                    input.SetSteering(-1f);
                    break;

                case ControlType.Right:
                    input.SetSteering(1f);
                    break;

                case ControlType.Throttle:
                    input.SetThrottle(true);
                    break;

                case ControlType.Brake:
                    input.SetBrake(true);
                    break;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (input == null) return;

            switch (control)
            {
                case ControlType.Left:
                case ControlType.Right:
                    input.SetSteering(0f);
                    break;

                case ControlType.Throttle:
                    input.SetThrottle(false);
                    break;

                case ControlType.Brake:
                    input.SetBrake(false);
                    break;
            }
        }
    }
}
