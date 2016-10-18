using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
    public ScoreManager score;

	void OnTriggerExit(Collider other) {
        if (other.tag == "Hostile")
        {
            score.AddMiss();

        }
        Destroy (other.gameObject);
		Debug.Log ("object destroyed", this);
	}


}
