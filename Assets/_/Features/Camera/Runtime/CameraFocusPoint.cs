using UnityEngine;

namespace CameraGame.Runtime
{
    public class CameraFocusPoint : MonoBehaviour
    {
        #region Public Members
        
        public static CameraFocusPoint Instance { get; set; }

        public Transform Player
        {
            get => _player;
            set => _player = value;
        }

        #endregion

        #region Unity API

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        /*
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        */

        private void Update()
        {
            if (Player is null || !Application.isFocused) return;
            
            Vector3 worldPosition = _camera.ScreenToWorldPoint(GetMousePosition());

            Vector3 target = new Vector3(
                worldPosition.x + (Player.position.x - worldPosition.x) / 4 * 3,
                worldPosition.y + (Player.position.y - worldPosition.y) / 8 * 5,
                transform.position.z);

            transform.position = Vector3.Lerp(transform.position, target, _lerpSpeed);
        }

        #endregion

        #region Main Methods

        private Vector3 GetMousePosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            if (mousePosition.x > Screen.width) mousePosition.x = Screen.width;
            if (mousePosition.x < 0) mousePosition.x = 0;
            if (mousePosition.y > Screen.height) mousePosition.y = Screen.height;
            if (mousePosition.y < 0) mousePosition.y = 0;
            return mousePosition;
        }

        #endregion

        #region Utils

        #endregion

        #region Private and Protected Members

        [SerializeField] private Camera _camera;
        [Range(0.01f, 1f)]
        [SerializeField] private float _lerpSpeed = 0.5f;
        
        private Transform _player;

        #endregion
    }
}