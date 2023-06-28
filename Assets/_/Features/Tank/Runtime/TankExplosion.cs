using UnityEngine;

namespace Tank.Runtime
{
    public class TankExplosion : MonoBehaviour
    {
    	#region Public Members

    	#endregion

    	#region Unity API
        private void OnTriggerEnter2D(Collider2D other)
        {
	        if (!other.CompareTag("Player"))return;
	        
	        other.GetComponent<TankHealth>().TakeDamage(_damage);
        }
    	#endregion

    	#region Main Methods

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private int _damage;

        #endregion
    }
}