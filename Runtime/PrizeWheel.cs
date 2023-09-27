using System;
using UnityEngine;

namespace IronMountain.PrizeWheels
{
    public class PrizeWheel : MonoBehaviour
    {
        public event Action OnValueChanged;
        public event Action OnStateChanged;
        public event Action<int> OnResult;
        
        public enum StateType
        {
            Spinning,
            Stopping,
            Stopped
        }

        [SerializeField] private int slices = 6;
        [SerializeField] [Range(0, 1)] private float offsetSlices = .5f;
        [SerializeField] private float degreesPerSecond = 360f;
        [SerializeField] private float secondsToStop = 2f;

        [Header("Cache")]
        private int _value;
        private StateType _state = StateType.Stopped;
        private float _stopTime;

        public int Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                OnValueChanged?.Invoke();
            }
        }

        public StateType State
        {
            get => _state;
            private set
            {
                if (_state == value) return;
                _state = value;
                OnStateChanged?.Invoke();
            }
        }

        public void StartSpinning()
        {
            State = StateType.Spinning;
        }

        public void Stop()
        {
            if (State != StateType.Spinning) return;
            _stopTime = Time.time;
            State = StateType.Stopping;
        }
        
        private void Update()
        {
            if (State == StateType.Spinning)
            {
                transform.Rotate(transform.forward, degreesPerSecond * Time.deltaTime);
                RefreshValue();
            }
            else if (State == StateType.Stopping)
            {
                float stopProgress = (Time.time - _stopTime) / secondsToStop;
                float degrees = Mathf.Lerp(degreesPerSecond * Time.deltaTime, 0, stopProgress);
                transform.Rotate(transform.forward, degrees);
                RefreshValue();
                if (stopProgress >= 1)
                {
                    State = StateType.Stopped;
                    OnResult?.Invoke(Value);
                }
            }
        }

        private void RefreshValue()
        {
            float multiplier = transform.eulerAngles.z / 360f;
            if (offsetSlices != 0) multiplier += 1f / slices * offsetSlices;
            if (multiplier > 1) multiplier -= 1;
            Value = Mathf.FloorToInt(multiplier * slices);
        }

        private void OnValidate()
        {
            if (slices < 1) slices = 1;
        }
    }
}
