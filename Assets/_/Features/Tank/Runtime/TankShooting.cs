using System;
using System.Collections;
using Mirror;
using UnityEngine;

namespace Tank.Runtime
{
    public class TankShooting : NetworkBehaviour
    {
    	#region Public Members

        public bool CanShoot
        {
	        get => _canShoot;
	        set => _canShoot = value;
        }

    	#endregion

        
    	#region Unity API

        private void OnEnable()
        {
	        _canShoot = true;
        }

        private void Update()
        {
	        if (!isOwned || !Input.GetMouseButton(0)) return;

	        if (_isInCooldown || !CanShoot) return;
	        CmdShoot();
        }

        #endregion

        
    	#region Main Methods

        [Command]
        private void CmdShoot()
        {
	        RpcShoot();
        }

        [ClientRpc]
        private void RpcShoot()
        {
	        Shoot();
        }

        private void Shoot()
        {
	        if (_isInCooldown || !CanShoot) return;
	        
	        GameObject currentShell = Instantiate(_bulletPrefabs, _shootingAnchor.position, _shootingAnchor.rotation);
	        
	        var shell = currentShell.GetComponent<Shell>();
	        shell.Speed = _bulletSpeed;
	        shell.Damage = _shellDamage;
	        shell.SourceDamage = GetComponent<Tank>();
	        
	        StartCoroutine(HandleCooldown(_shootingCooldown));
        }

        private IEnumerator HandleCooldown(float rate)
        {
	        _isInCooldown = true;
	        yield return new WaitForSeconds(rate);
	        _isInCooldown = false;
        }

    	#endregion

        
    	#region Utils

    	#endregion

        
    	#region Private and Protected Members

        [SerializeField] private GameObject _bulletPrefabs;
        [SerializeField] private Transform _shootingAnchor;

        [Space]
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private int _shellDamage;
        [SerializeField] private float _shootingCooldown;
        
        private bool _isInCooldown;
        private bool _canShoot;

        #endregion
    }
}
