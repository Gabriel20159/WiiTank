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

        public Tank SourceDamage
        {
            get => sourceDamage;
            set => sourceDamage = value;
        }

        #endregion

        #region Private and Protected Members
        
        protected int _damage;

        protected Tank sourceDamage;

        #endregion
    }
}