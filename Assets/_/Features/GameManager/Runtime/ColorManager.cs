using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameManagerFeature.Runtime
{
    public class ColorManager : MonoBehaviour
    {
        public static ColorManager Instance { get; private set; }

        #region Unity API

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            _availableColorList = new (_colors);
            Instance = this;
        }

        #endregion

        #region Main Methods

        public Color GetAvailableColor()
        {
            if (_availableColorList.Count == 0) return Color.black;
            
            Color color = _availableColorList[Random.Range(0, _availableColorList.Count)];
            _availableColorList.Remove(color);
            return color;
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private Color[] _colors = new Color[12];
        private List<Color> _availableColorList = new();

        #endregion
    }
}