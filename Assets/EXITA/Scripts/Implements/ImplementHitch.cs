using UnityEngine;

namespace ExitaUtara
{
    public class ImplementHitch : MonoBehaviour
    {
        [SerializeField] private Transform hitchPoint;
        private ImplementMount attached;

        public bool Attach(ImplementMount implement)
        {
            if (implement == null || attached != null || hitchPoint == null) return false;
            attached = implement;
            implement.transform.SetParent(hitchPoint, false);
            if (implement.MountPoint != null)
            {
                implement.transform.localPosition = -implement.MountPoint.localPosition;
                implement.transform.localRotation = Quaternion.Inverse(implement.MountPoint.localRotation);
            }
            return true;
        }

        public void Detach()
        {
            if (attached == null) return;
            attached.transform.SetParent(null, true);
            attached = null;
        }
    }
}
