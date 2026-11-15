using UnityEngine;

namespace ExitaUtara
{
    // Assign a properly licensed diesel engine/exhaust recording in the Inspector.
    // This controller changes pitch and volume with throttle and vehicle speed.
    [RequireComponent(typeof(AudioSource))]
    public class EngineExhaustAudio : MonoBehaviour
    {
        [SerializeField] private VehicleDrive vehicle;
        [SerializeField] private float idlePitch = 0.78f;
        [SerializeField] private float fullLoadPitch = 1.35f;
        [SerializeField] private float idleVolume = 0.25f;
        [SerializeField] private float loadVolume = 0.9f;
        [SerializeField] private float response = 3f;

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            source.loop = true;
            source.playOnAwake = false;
        }

        private void Update()
        {
            if (vehicle == null || source.clip == null) return;
            if (!source.isPlaying) source.Play();

            float load = Mathf.Clamp01(Mathf.Abs(vehicle.Throttle) * 0.75f
                                      + vehicle.SpeedKph / 100f * 0.25f);
            float targetPitch = Mathf.Lerp(idlePitch, fullLoadPitch, load);
            float targetVolume = Mathf.Lerp(idleVolume, loadVolume, load);

            source.pitch = Mathf.Lerp(source.pitch, targetPitch, Time.deltaTime * response);
            source.volume = Mathf.Lerp(source.volume, targetVolume, Time.deltaTime * response);
        }
    }
}
