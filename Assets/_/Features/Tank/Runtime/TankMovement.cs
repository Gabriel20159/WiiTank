using System;
using CameraGame.Runtime;
using Mirror;
using UnityEngine;

namespace Tank.Runtime
{
    public class TankMovement : NetworkBehaviour
    {
    	#region Public Members
		
    	#endregion

    	#region Unity API

        private void Start()
        {
	        if (!isOwned) return;

	        CameraFocusPoint.Instance.Player = transform;
        }

        private void Update()
        {
	        if (!isOwned) return;
	        
	        transform.position += transform.up * (Input.GetAxisRaw("Vertical") * _forwardSpeed * Time.deltaTime);
	        
	        transform.Rotate(new Vector3(0, 0, -Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime));
        }

        #endregion

    	#region Main Methods

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _rotationSpeed;

        #endregion
    }
}