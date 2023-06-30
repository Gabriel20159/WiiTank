using System;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class ScoreManager : MonoBehaviour
    {
        #region Public Members
        
        public static ScoreManager Instance { get; private set; }
        public EventHandler<int> m_onKillCountChanged;

        #endregion

        #region Unity API

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        #endregion

        #region Main Methods
        
        public void IncrementKillCount()
        {
            Debug.Log("Got a kill.");
            _killCount++;
            m_onKillCountChanged?.Invoke(this, _killCount);
        }

        #endregion

        #region Private and Protected Members

        private int _killCount;

        #endregion
    }
}