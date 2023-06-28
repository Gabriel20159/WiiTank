using System;
using TMPro;
using UnityEngine;
using Utils.Runtime;

namespace HUD.Runtime
{
    public class DisplayTime : TimerBehaviour
    {
        #region Unity API

        private void Start()
        {
            m_onTimerEnd += OnTimerEndEventHandler;
            StartTimer(_maxTimerValue);
        }

        protected override void Update()
        {
            base.Update();
            
            _timerTMP.text = GetTimerCurrentString();
        }

        private void OnValidate()
        {
            if (_maxTimerValue < 0.01f) _maxTimerValue = 0.01f;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("StartTimer")) StartTimer(_maxTimerValue);
            if (GUILayout.Button("PauseTimer")) PauseTimer(true);
            if (GUILayout.Button("UnPauseTimer")) PauseTimer(false);
            if (GUILayout.Button("StopTimer")) StopTimer();
            GUILayout.EndHorizontal();
        }

        #endregion

        #region My Methods

        private void OnTimerEndEventHandler(object sender, EventArgs e)
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private TMP_Text _timerTMP;
        
        [Space]
        [Tooltip("In second \nThe minimum is 0.01")]
        [SerializeField] private float _maxTimerValue;

        #endregion
    }
}