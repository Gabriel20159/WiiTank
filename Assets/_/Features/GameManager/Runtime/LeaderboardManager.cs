using System;
using System.Linq;
using Mirror;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class LeaderboardManager : MonoBehaviour
    {
        public static LeaderboardManager Instance { get; private set; }
        
        public EventHandler<NetworkIdentity[]> m_onUpdateLeaderboard;

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
        
        public void UpdateLeaderboard()
        {
            m_onUpdateLeaderboard?.Invoke(this, NetworkClient.spawned.Values.ToArray());
        }
    }
}