using System;
using Mirror;

namespace Tank.Runtime
{
    public class TankScore : NetworkBehaviour
    {
        public EventHandler<int> m_onKillCountChanged;

        public int KillCount
        {
            get => _killCount;
            set => _killCount = value;
        }

        public void IncrementKillCount()
        {
            KillCount++;
            m_onKillCountChanged?.Invoke(this, KillCount);
        }
        
        [SyncVar] private int _killCount;
    }
}