using UnityEngine;

namespace Tank.Runtime
{
    public class TankExplosion : TankDamager
    {
    	#region Public Members

    	#endregion

    	#region Unity API
        private void OnTriggerEnter2D(Collider2D other)
        {
	        if (!other.CompareTag("Player"))return;

	        _damage = 1000;
	        other.GetComponent<TankHealth>().TakeDamage(this);
        }
    	#endregion

    	#region Main Methods

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        #endregion
    }
}