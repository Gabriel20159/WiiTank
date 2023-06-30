using System;
using Mirror;
using Tank.Runtime;
using TMPro;
using UnityEngine;

namespace HUD.Runtime
{
    public class TankScoreHUD : MonoBehaviour
    {
        #region Unity API

        private void OnEnable()
        {
            if (_tankScore is null) return;
            
            _tankScore.m_onKillCountChanged += OnKillCountChanged;
        }

        private void OnDisable()
        {
            _tankScore.m_onKillCountChanged -= OnKillCountChanged;
        }

        private void Start()
        {
            OnKillCountChanged(this, 0);
        }

        private void Update()
        {
            if (_tankScore is not null) return;
            
            NetworkIdentity tankIdentity = NetworkClient.localPlayer;
            if (tankIdentity is null) return;
            
            _tankScore = tankIdentity.GetComponentInChildren<TankScore>();
            _tankScore.m_onKillCountChanged += OnKillCountChanged;
        }

        #endregion

        #region Main Methods

        private void OnKillCountChanged(object sender, int e)
        {
            _killCountText.text = $"Kills: {e}";
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private TextMeshProUGUI _killCountText;

        private TankScore _tankScore;

        #endregion
    }
}