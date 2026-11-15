using UnityEngine;

namespace ExitaUtara
{
    public enum FieldImplementType
    {
        Plough, Rotavator, LandLeveller, RiceTransplanter,
        FertilizerSpreader, Sprayer, HarvesterHeader, PaddyTrailer
    }

    // Place this component on a real implement prefab and assign its mount point.
    public class ImplementMount : MonoBehaviour
    {
        [SerializeField] private FieldImplementType implementType;
        [SerializeField] private Transform mountPoint;
        public FieldImplementType Type => implementType;
        public Transform MountPoint => mountPoint;
    }
}
