
using UnityEngine;

namespace ExitaUtara
{
    [RequireComponent(typeof(AudioSource))]
    public class EngineExhaustAudio : MonoBehaviour
    {
        [Header("Vehicle")]
        [SerializeField] private VehicleDrive vehicle;

        [Header("Diesel Engine")]
        [SerializeField] private float idlePitch = 0.78f;
        [SerializeField] private float fullLoadPitch = 1.35f;
        [SerializeField] private float idleVolume = 0.25f;
        [SerializeField] private float loadVolume = 0.9f;

        [Header("Turbo Sound")]
        [SerializeField] private AudioSource turboSource;
        [SerializeField] private float turboIdleVolume = 0f;
        [SerializeField] private float turboFullVolume = 0.65f;
        [SerializeField] private float turboPitch = 1.2f;

        [Header("Response")]
        [SerializeField] private float response = 3f;

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();

            source.loop = true;
            source.playOnAwake = false;

            if (turboSource != null)
            {
                turboSource.loop = true;
                turboSource.playOnAwake = false;
            }
        }

        private void Update()
        {
            if (vehicle == null)
                return;

            float load = Mathf.Clamp01(
                Mathf.Abs(vehicle.Throttle) * 0.75f +
                vehicle.SpeedKph / 100f * 0.25f
            );

            UpdateEngine(load);
            UpdateTurbo(load);
        }

        private void UpdateEngine(float load)
        {
            if (source.clip == null)
                return;

            if (!source.isPlaying)
                source.Play();

            float targetPitch = Mathf.Lerp(
                idlePitch,
                fullLoadPitch,
                load
            );

            float targetVolume = Mathf.Lerp(
                idleVolume,
                loadVolume,
                load
            );

            source.pitch = Mathf.Lerp(
                source.pitch,
                targetPitch,
                Time.deltaTime * response
            );

            source.volume = Mathf.Lerp(
                source.volume,
                targetVolume,
                Time.deltaTime * response
            );
        }

        private void UpdateTurbo(float load)
        {
            if (turboSource == null || turboSource.clip == null)
                return;

            if (!turboSource.isPlaying)
                turboSource.Play();

            float targetVolume = Mathf.Lerp(
                turboIdleVolume,
                turboFullVolume,
                load
            );

            turboSource.pitch = turboPitch;

            turboSource.volume = Mathf.Lerp(
                turboSource.volume,
                targetVolume,
                Time.deltaTime * response
            );
        }

        private void OnDisable()
        {
            if (source != null)
                source.Stop();

            if (turboSource != null)
                turboSource.Stop();
        }
    }
}
