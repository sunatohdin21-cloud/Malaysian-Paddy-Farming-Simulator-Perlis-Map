using UnityEngine;

namespace ExitaUtara
{
    public class ThirdPersonVehicleCamera : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform target;

        [Header("Camera Settings")]
        [SerializeField] private float distance = 7f;
        [SerializeField] private float height = 3f;
        [SerializeField] private float followSpeed = 5f;
        [SerializeField] private float rotationSpeed = 5f;

        [Header("Look")]
        [SerializeField] private float lookHeight = 1.5f;

        private void LateUpdate()
        {
            if (target == null) return;

            Vector3 desiredPosition =
                target.position -
                target.forward * distance +
                Vector3.up * height;

            transform.position = Vector3.Lerp(
                transform.position,
                desiredPosition,
                followSpeed * Time.deltaTime
            );

            Quaternion desiredRotation = Quaternion.LookRotation(
                target.position + Vector3.up * lookHeight -
                transform.position
            );

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                desiredRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}
