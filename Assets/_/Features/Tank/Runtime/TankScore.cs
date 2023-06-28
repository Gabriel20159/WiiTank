using System;
using Mirror;

namespace Tank.Runtime
{
    public class TankScore : NetworkBehaviour
    {
        #region Public Members
        
        public static TankScore Instance { get; private set; }
        public EventHandler<int> m_onKillCountChanged;

        #endregion

        #region Unity API

        private void Awake()
        {
            if (Instance != null || !isOwned)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        #endregion

        #region Main Methods

        public void ChangeKillCount(int value)
        {
            _killCount += value;
            m_onKillCountChanged?.Invoke(this, _killCount);
        }

        #endregion

        #region Private and Protected Members

        private int _killCount;

        #endregion
    }
}