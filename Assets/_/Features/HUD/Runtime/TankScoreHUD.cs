using GameManagerFeature.Runtime;
using TMPro;
using UnityEngine;

namespace HUD.Runtime
{
    public class TankScoreHUD : MonoBehaviour
    {
        #region Unity API

        private void OnEnable()
        {
            ScoreManager.Instance.m_onKillCountChanged += OnKillCountChanged;
        }

        private void OnDisable()
        {
            ScoreManager.Instance.m_onKillCountChanged -= OnKillCountChanged;
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
        
        #endregion
    }
}