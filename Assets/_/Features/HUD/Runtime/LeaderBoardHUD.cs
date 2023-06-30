using System.Linq;
using GameManagerFeature.Runtime;
using Mirror;
using Tank.Runtime;
using TMPro;
using UnityEngine;

namespace HUD.Runtime
{
    public class LeaderBoardHUD : MonoBehaviour
    {
        private void Awake()
        {
            _scoreTexts = new TextMeshProUGUI[_leaderBoardTextParent.childCount];
            for (int i = 0; i < _leaderBoardTextParent.childCount; i++)
            {
                _scoreTexts[i] = _leaderBoardTextParent.GetChild(i).GetComponent<TextMeshProUGUI>();
            }
        }

        private void OnEnable()
        {
            LeaderboardManager.Instance.m_onUpdateLeaderboard += OnUpdateLeaderboardEventHandler;
        }

        private void OnUpdateLeaderboardEventHandler(object sender, NetworkIdentity[] e)
        {
            UpdateLeaderBoard(e);
        }

        private void UpdateLeaderBoard(NetworkIdentity[] networkIdentities)
        {
            NetworkIdentity[] sortedScores = networkIdentities.OrderBy(o=>o.GetComponentInChildren<TankScore>(true).KillCount).ToArray();
            for (int i = 0; i < _scoreTexts.Length; i++)
            {
                _scoreTexts[i].text = sortedScores.Length > i ? $"{sortedScores[i].name} : {sortedScores[i].GetComponentInChildren<TankScore>(true).KillCount} kills" : "";
            }
        }

        [SerializeField] private Transform _leaderBoardTextParent;
        private TextMeshProUGUI[] _scoreTexts;
    }
}