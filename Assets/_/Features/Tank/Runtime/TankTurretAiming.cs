using Mirror;
using UnityEngine;

namespace Tank.Runtime
{
    public class TankTurretAiming : NetworkBehaviour
    {
    	#region Public Members

    	#endregion

    	#region Unity API

        private void Start()
        {
	        _camera = Camera.main;
        }

        private void Update()
        {
	        if (!isOwned) return;
	        
	        Vector2 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
	        var turretPosition = _turret.position;
	        
	        float zRotation = Mathf.Atan2(worldPosition.y - turretPosition.y, worldPosition.x - turretPosition.x) * Mathf.Rad2Deg - 90;
	        _turret.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
        }

        #endregion

    	#region Main Methods

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private Transform _turret;
        
        private Camera _camera;

        #endregion
    }
}