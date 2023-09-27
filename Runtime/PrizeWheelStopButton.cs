using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.PrizeWheels
{
    [RequireComponent(typeof(Button))]
    public class PrizeWheelStopButton : MonoBehaviour
    {
        [SerializeField] private PrizeWheel prizeWheel;
        
        [Header("Cache")]
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            if (!prizeWheel) prizeWheel = GetComponentInParent<PrizeWheel>();
        }

        private void OnEnable()
        {
            if (_button) _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            if (_button) _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (prizeWheel) prizeWheel.Stop();
        }

        private void OnValidate()
        {
            if (!prizeWheel) prizeWheel = GetComponentInParent<PrizeWheel>();
        }
    }
}