//usingRemi

using System;
using System.Collections;
using GameManagerFeature.Runtime;
using UnityEngine;

namespace Tank.Runtime
{
    public class OnHealthChangedEventArgs : EventArgs
    {
        public int Health { get; set; }
    }
    
    public class TankHealth : MonoBehaviour
    {
        #region Public Members

        public EventHandler<OnHealthChangedEventArgs> m_onHealthChanged;
        public EventHandler m_onRespawn;

        public int MaxHealth
        {
            get => _maxHealth;
        }

        private bool IsInvincible
        {
            get => _isInvincible;
            set => _isInvincible = value;
        }

        private int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                if (_currentHealth < 0) _currentHealth = 0;
            }
        }

        #endregion
        
        
        #region Unity API

        private void Awake()
        {
            _tankShooting = GetComponent<TankShooting>();
            if (_tankShooting is null) Debug.LogError("TankShooting component is missing.", transform);
        }

        private void OnEnable()
        {
            Spawn();
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) TakeDamage(1000);
        }

        #endregion
                
        
        #region Main Methods

        public void TakeDamage(int damage)
        {
            if (IsInvincible) return;
            
            CurrentHealth -= damage;
            if (CurrentHealth < 0) CurrentHealth = 0;
            
            m_onHealthChanged?.Invoke(this, new OnHealthChangedEventArgs { Health = CurrentHealth });
            
            if (CurrentHealth <= 0) Die();
        }

        private void Die()
        {
            Instantiate(_dieVFX, transform.position, Quaternion.identity);
            SpawnManager.Instance.Respawn(transform);
        }

        private void Spawn()
        {
            CurrentHealth = _maxHealth;
            
            m_onRespawn?.Invoke(this, EventArgs.Empty);
            
            StartCoroutine(SpriteBlink());
        }

        private IEnumerator SpriteBlink()
        {
            _tankShooting.CanShoot = false;
            IsInvincible = true;
            
            float _blinkCount = _invincibleTime / _blinkTime;
            int alpha = 1;
            
            for (int i = 0; i < _blinkCount * 2; i++)
            {
                alpha = alpha == 0 ? 1 : 0;
                
                foreach (var sprite in _tankSpriteRenderers)
                {
                    Color currentColor = sprite.color;
                    currentColor.a = alpha;
                
                    sprite.color = currentColor;
                }
                yield return new WaitForSeconds(_blinkTime / 2);
            }
            
            IsInvincible = false;
            _tankShooting.CanShoot = true;
        }

        #endregion
        
        
        #region Private and Protected Members

        [SerializeField] private SpriteRenderer[] _tankSpriteRenderers;
        [SerializeField] private GameObject _dieVFX;
        
        [Space]
        [SerializeField] private int _maxHealth;

        [Header("Respawn")]
        [Range(1, 10)]
        [SerializeField] private int _invincibleTime;
        
        private TankShooting _tankShooting;

        private const float _blinkTime = 0.2f;

        private bool _isInvincible;
        private int _currentHealth;

        #endregion

    }
}