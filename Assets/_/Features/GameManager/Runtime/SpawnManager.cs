using System.Collections;
using System.Linq;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class SpawnManager : MonoBehaviour
    {
    	#region Public Members

        public static SpawnManager Instance { get; private set; }

        #endregion

        
    	#region Unity API

        private void Awake()
        {
	        Instance = this;
        }

        private void Start()
        {
	        _spawnAnchors = new SpawnAnchor[transform.childCount];
	        for (int i = 0; i < transform.childCount; i++)
	        {
		        _spawnAnchors[i] = transform.GetChild(i).GetComponent<SpawnAnchor>();
	        }
        }

        #endregion

        
    	#region Main Methods

        public void Respawn(Transform transformToRespawn)
        {
	        StartCoroutine(WaitToRespawn(transformToRespawn));
        }

        private IEnumerator WaitToRespawn(Transform transformToRespawn)
        {
	        transformToRespawn.gameObject.SetActive(false);
	        
	        yield return new WaitForSeconds(_timeBeforeSpawn);
	        
	        transformToRespawn.gameObject.SetActive(true);
	        transformToRespawn.position = GetAvailableSpawnAnchor().transform.position;
        }

        private SpawnAnchor GetAvailableSpawnAnchor()
        {
		    System.Random rand = new System.Random();
		    SpawnAnchor[] shuffledSpawnAnchors = _spawnAnchors.OrderBy(_ => rand.Next()).ToArray();
	        
	        SpawnAnchor leastPlayersInContact = shuffledSpawnAnchors[0];
	        foreach (var spawnAnchor in shuffledSpawnAnchors)
	        {
		        if (spawnAnchor.PlayersInContact.Count == 0)
		        {
			        return spawnAnchor;
		        }
		        else if (spawnAnchor.PlayersInContact.Count < leastPlayersInContact.PlayersInContact.Count)
		        {
			        leastPlayersInContact = spawnAnchor;
		        }
	        }
	        return leastPlayersInContact;
        }
        
    	#endregion

        
    	#region Utils

    	#endregion

        
    	#region Private and Protected Members

        [SerializeField] private float _timeBeforeSpawn;
        private SpawnAnchor[] _spawnAnchors;

        #endregion
    }
}