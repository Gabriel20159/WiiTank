using System;
using UnityEngine;

namespace Utils.Runtime
{
    public class TimerBehaviour : MonoBehaviour
    {
        #region Public Members

        public EventHandler<EventArgs> m_onTimerStart;
        public EventHandler<EventArgs> m_onTimerPerformed;
        public EventHandler<EventArgs> m_onTimerEnd;

        #endregion


        #region Unity API

        protected virtual void Update()
        {
            if (_isPaused) return;

            if (_currentTimeBeforeStart > 0)
            {
                _currentTimeBeforeStart -= Time.deltaTime;
                if (_currentTimeBeforeStart <= 0)
                {
                    StartTimer(MaxTimer);
                }
            }

            switch (_currentState)
            {
                case State.Start:
                    _currentTime = MaxTimer;
                    m_onTimerStart?.Invoke(this, EventArgs.Empty);
                    _currentState = State.Performed;
                    break;

                case State.Performed:
                    m_onTimerPerformed?.Invoke(this, EventArgs.Empty);
                    if (_currentTime > 0)
                    {
                        _currentTime -= Time.deltaTime;
                        if (_currentTime <= 0)
                        {
                            _currentTime = 0;
                            _currentState = State.End;
                        }
                    }
                    break;

                case State.End:
                    m_onTimerEnd?.Invoke(this, EventArgs.Empty);
                    _currentState = State.Inactive;
                    break;
            }
        }

        #endregion


        #region Main Methods

        // Can start/restart with a delay
        public void StartTimer(float duration, float timeToWaitBeforeStart = 0)
        {
            if (timeToWaitBeforeStart > 0)
            {
                _currentTimeBeforeStart = timeToWaitBeforeStart;
                return;
            }

            MaxTimer = duration;
            _isPaused = false;
            _currentState = State.Start;
        }

        //  Pause start timer and current timer
        public void PauseTimer(bool isPaused)
        {
            _isPaused = isPaused;
        }

        //  Disable start timer and current timer
        public void StopTimer()
        {
            _isPaused = false;
            _currentTimeBeforeStart = 0;
            _currentTime = 0;

            _currentState = State.Inactive;
        }

        //  Get the value of the current timer only
        public float GetTimerCurrentValue()
        {
            return _currentTime;
        }
        
        public string GetTimerCurrentString(bool isCeiling = false)
        {
            int time;
            if (isCeiling && _currentState != State.Inactive) time = (int)_currentTime + 1;
            else time = (int)_currentTime;
            
            int seconds = time % 60;
            int minutes = time / 60;
            return $"{minutes:00}:{seconds:00}";
        }

        #endregion


        #region Private and Protected Members

        private float _maxTimer;

        private float MaxTimer
        {
            get => _maxTimer;
            set
            {
                if (value < 0.01f)
                {
                    value = 0.01f;
                }

                _maxTimer = value;
            }
        }

        private float _currentTime;
        private float _currentTimeBeforeStart;
        private bool _isPaused;

        private State _currentState;

        private enum State
        {
            Inactive,

            Start,
            Performed,
            End
        }

        #endregion
    }
}