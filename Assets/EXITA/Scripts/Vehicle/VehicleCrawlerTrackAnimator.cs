
using UnityEngine;

namespace ExitaUtara
{
    public class VehicleCrawlerTrackAnimator : MonoBehaviour
    {
        [SerializeField] private Rigidbody vehicleBody;

        [Header("Left Track")]
        [SerializeField] private Transform leftDriveWheel;
        [SerializeField] private Transform[] leftRollers;

        [Header("Right Track")]
        [SerializeField] private Transform rightDriveWheel;
        [SerializeField] private Transform[] rightRollers;

        [SerializeField] private float rotationSpeed = 180f;

        private void Update()
        {
            if (vehicleBody == null) return;

            float speed = Vector3.Dot(
                vehicleBody.velocity,
                transform.forward
            );

            float rotation = speed * rotationSpeed *
                            Time.deltaTime;

            RotateTrack(leftDriveWheel, leftRollers, rotation);
            RotateTrack(rightDriveWheel, rightRollers, rotation);
        }

        private void RotateTrack(
            Transform driveWheel,
            Transform[] rollers,
            float rotation)
        {
            if (driveWheel != null)
                driveWheel.Rotate(Vector3.right, rotation);

            if (rollers == null) return;

            foreach (Transform roller in rollers)
            {
                if (roller != null)
                    roller.Rotate(Vector3.right, rotation);
            }
        }
    }
}
