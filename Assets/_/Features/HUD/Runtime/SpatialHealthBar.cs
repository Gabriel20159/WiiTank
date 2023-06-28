using System;
using Tank.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.Runtime
{
    public class SpatialHealthBar : MonoBehaviour
    {
    	#region Public Members


        #endregion

        
    	#region Unity API

        private void Start()
        {
	        _tankMaxHealth = _tankHealth.MaxHealth;
	        
	        _tankHealth.m_onHealthChanged += OnHealthChangedEventHandler;
	        _tankHealth.m_onRespawn += OnRespawnEventHandler;
        }


        private void Update()
        {
	        if (_deltaFill >= 1) return;
	        
	        _deltaFill += Time.deltaTime / (_isRespawning ? _fillDurationRespawning : _fillDuration);
	        _healthBarFill.fillAmount = Mathf.Lerp(_oldFill, _targetFill, _fillAnimationCurve.Evaluate(_deltaFill));
        }

        #endregion

        
    	#region Main Methods
        
        private void OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
        {
	        _oldFill = _healthBarFill.fillAmount;
	        _targetFill = e.Health / (float)_tankMaxHealth;
	        
	        _deltaFill = 0;

	        _isRespawning = false;
        }

        private void OnRespawnEventHandler(object sender, EventArgs e)
        {
	        _oldFill = 0;
	        _targetFill = 1;

	        _deltaFill = 0;

	        _isRespawning = true;
        }
        
    	#endregion

        
    	#region Utils

    	#endregion

        
    	#region Private and Protected Members

        [SerializeField] private TankHealth _tankHealth;
        [SerializeField] private Image _healthBarFill;
        
        [Space]
        [Range(0.01f, 2f)]
        [SerializeField] private float _fillDuration = 1f;
        [Range(0.01f, 10f)]
        [SerializeField] private float _fillDurationRespawning = 3f;
        [SerializeField] private AnimationCurve _fillAnimationCurve;

        private int _tankMaxHealth;
        
        private bool _isRespawning = true;
        private float _oldFill;
        private float _targetFill = 1;
        private float _deltaFill;

        #endregion
    }
}