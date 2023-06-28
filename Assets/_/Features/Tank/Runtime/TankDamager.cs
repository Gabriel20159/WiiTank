using UnityEngine;

namespace Tank.Runtime
{
    public class TankDamager : MonoBehaviour
    {
        #region Public Members

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public TankShooting Source
        {
            get => _source;
            set => _source = value;
        }

        #endregion

        #region Private and Protected Members
        
        protected int _damage;

        protected TankShooting _source;

        #endregion
    }
}