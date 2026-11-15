
using UnityEngine;
using UnityEngine.EventSystems;

namespace ExitaUtara
{
    public class MobileTractorJoystick : MonoBehaviour,
        IPointerDownHandler, IPointerUpHandler,
        IDragHandler
    {
        [SerializeField] private RectTransform joystickArea;
        [SerializeField] private RectTransform handle;
        [SerializeField] private MobileTractorInput input;
        [SerializeField] private float handleRange = 60f;

        private Vector2 inputVector;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (joystickArea == null || handle == null || input == null)
                return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                joystickArea,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 position
            );

            Vector2 halfSize = joystickArea.rect.size * 0.5f;

            inputVector.x = Mathf.Clamp(
                position.x / halfSize.x, -1f, 1f
            );

            inputVector.y = Mathf.Clamp(
                position.y / halfSize.y, -1f, 1f
            );

            handle.anchoredPosition =
                inputVector * handleRange;

            input.SetSteering(inputVector.x);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector2.zero;

            if (handle != null)
                handle.anchoredPosition = Vector2.zero;

            if (input != null)
                input.SetSteering(0f);
        }
    }
}
