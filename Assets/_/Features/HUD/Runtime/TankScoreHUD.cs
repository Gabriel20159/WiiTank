using System;
using Tank.Runtime;
using TMPro;
using UnityEngine;

namespace HUD.Runtime
{
    public class TankScoreHUD : MonoBehaviour
    {
        #region Unity API

        private void Update()
        {
            if (_tankScore is not null) return;

            TankScore.Instance.m_onKillCountChanged += OnKillCountChanged;
        }

        #endregion

        #region Main Methods

        private void OnKillCountChanged(object sender, int e)
        {
            _killCountText.text = $"{e}";
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private TextMeshProUGUI _killCountText;

        private TankScore _tankScore;

        #endregion
    }
}