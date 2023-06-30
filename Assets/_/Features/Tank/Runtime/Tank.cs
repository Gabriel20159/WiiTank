using System.Collections;
using System.Threading.Tasks;
using GameManagerFeature.Runtime;
using Mirror;
using UnityEngine;

namespace Tank.Runtime
{
    public class Tank : NetworkBehaviour
    {
        private void Awake()
        {
            StartCoroutine(UpdateLeaderboard());
        }

        private IEnumerator UpdateLeaderboard()
        {
            yield return new WaitForSeconds(0.1f);
            LeaderboardManager.Instance.UpdateLeaderboard();
        }
    }
}