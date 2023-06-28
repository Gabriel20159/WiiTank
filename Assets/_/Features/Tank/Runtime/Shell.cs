using System;
using UnityEngine;

namespace Tank.Runtime
{
    public class Shell : MonoBehaviour
    {
    	#region Public Members

        public float Speed
        {
	        get => _speed;
	        set => _speed = value;
        }

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

    	#region Unity API

        private void FixedUpdate()
        {
	        transform.position += transform.up * (_speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
	        if (!other.CompareTag("Player"))
	        {
		        Die();
		        return;
	        }
	        
	        other.GetComponent<TankHealth>().TakeDamage(_damage);
	        Die();
        }

        private void Die()
        {
	        Instantiate(_hitVFX, transform.position, Quaternion.identity);
	        Destroy(gameObject);
        }
        
        #endregion

    	#region Main Methods

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private GameObject _hitVFX;
        
        private int _damage;
        private float _speed;

        private TankShooting _source;

        #endregion

    }
}