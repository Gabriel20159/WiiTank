using System.Collections.Generic;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class PlayersProfilesDataBase : MonoBehaviour
    {
        #region My Methods

        public void SetNewPlayer(int id, string username)
        {
            foreach (var playerProfile in _playerProfiles)
            {
                if (!VerifyIfIsExisting(id, playerProfile)) return;

                username = SetUsername(username, playerProfile);
            }

            InitializePlayerProfile(id, username);
        }
        
        #endregion

        
        #region Utils

        private bool VerifyIfIsExisting(int id, PlayerProfile playerProfile)
        {
            return playerProfile.m_id == id;
        }

        private string SetUsername(string username, PlayerProfile playerProfile)
        {
            if (playerProfile.m_username.Equals(username))
            {
                username = $"Perdant{++_perdantIndex}";
            }

            return username;
        }

        private void InitializePlayerProfile(int id, string username)
        {
            PlayerProfile current = new PlayerProfile { m_id = id, m_username = username, m_color = ClaimRandomColor() };
            _playerProfiles.Add(current);
        }

        private Color ClaimRandomColor()
        {
            Color color = _colorList[Random.Range(0, _colorList.Count - 1)];
            _colorList.Remove(color);
            return color;
        }

        #endregion
        
        
        #region Private and Protected Members

        [SerializeField] private List<PlayerProfile> _playerProfiles = new List<PlayerProfile>();
        [SerializeField] private List<Color> _colorList = new List<Color>();

        private int _perdantIndex;

        private struct PlayerProfile
        {
            public int m_id;
            public string m_username;
            public Color m_color;
        }
        
        #endregion
    }
}