using System.Collections.Generic;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class SpawnAnchor : MonoBehaviour
    {
    	#region Public Members

        public List<Collider2D> PlayersInContact { get => _playersInContact; }

    	#endregion

    	#region Unity API

        private void OnTriggerEnter2D(Collider2D other)
        {
	        if (!other.CompareTag("Player")) return;
	        
	        PlayersInContact.Add(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
	        if (!other.CompareTag("Player")) return;
	        
	        PlayersInContact.Remove(other);
        }

        #endregion

    	#region Main Methods

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        private List<Collider2D> _playersInContact = new();

        #endregion
    }
}