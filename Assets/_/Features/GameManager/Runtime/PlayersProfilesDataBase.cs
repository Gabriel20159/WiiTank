using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class PlayersProfilesDataBase : MonoBehaviour
    {
        #region My Methods

        public void SetNewPlayer(int id, string name)
        {
            //  Verify if this player is already set
            //  And verify if the name is taken
            for (int i = 0; i < _playerProfiles.Count; i++)
            {
                if (_playerProfiles[i].m_id == id) return;
                
                if (_playerProfiles[i].m_name.Equals(name))
                {
                    name = $"Perdant{i}";
                }
            }

            //  Set random color
            Color color = _colorList[Random.Range(0, _colorList.Count - 1)];
            _colorList.Remove(color);

            //  Initialize PlayerProfile
            PlayerProfile current = new PlayerProfile { m_id = id, m_name = name, m_color = color };
            _playerProfiles.Add(current);
        }

        #endregion
        
        
        #region Private and Protected Members

        [SerializeField] private List<PlayerProfile> _playerProfiles = new List<PlayerProfile>();
        [SerializeField] private List<Color> _colorList = new List<Color>();

        private struct PlayerProfile
        {
            public int m_id;
            public string m_name;
            public Color m_color;
        }
        
        #endregion
    }
}