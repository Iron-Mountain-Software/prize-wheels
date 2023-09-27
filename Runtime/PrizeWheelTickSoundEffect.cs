using UnityEngine;

namespace IronMountain.PrizeWheels
{
    [RequireComponent(typeof(AudioSource))]
    public class PrizeWheelTickSoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private PrizeWheel prizeWheel;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            if (!prizeWheel) prizeWheel = GetComponentInParent<PrizeWheel>();
            if (!audioSource) audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            if (prizeWheel) prizeWheel.OnValueChanged += PlayTick;
        }

        private void OnDisable()
        {
            if (prizeWheel) prizeWheel.OnValueChanged -= PlayTick;
        }

        private void PlayTick()
        {
            if (!audioSource || !audioClip) return;
            audioSource.PlayOneShot(audioClip);
        }

        private void OnValidate()
        {
            if (!prizeWheel) prizeWheel = GetComponentInParent<PrizeWheel>();
            if (!audioSource) audioSource = GetComponent<AudioSource>();
        }
    }
}
