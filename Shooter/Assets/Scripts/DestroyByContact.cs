using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	//public int killsValue;
	//private EnemyManager enemyManager;

	/*void Start () {
		GameObject enemyManagerObject = GameObject.FindWithTag ("EnemyManager");
		if (enemyManager != null) {
			enemyManager = enemyManagerObject.GetComponent <EnemyManager> ();
		}
		if (enemyManager == null) {
			Debug.Log ("Cannot find 'enemyManager' script");
		}
	}*/


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boundary") 
		{
			return;
		}

		if (other.gameObject.tag == "Target") 
		{
			return;
		}

		if (other.gameObject.tag == gameObject.tag) {
			return;
		}
			
		Destroy (other.gameObject);
		Destroy (gameObject);
		Debug.Log (other.gameObject.name + " destroyed " + gameObject.name, this);
		//enemyManager.AddKills (killsValue);
	}
}
