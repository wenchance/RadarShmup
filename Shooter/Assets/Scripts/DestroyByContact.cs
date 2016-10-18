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

    private ScoreManager score;
    private GameManager game;

    void Start ()
    {
        score = FindObjectOfType<ScoreManager>();
        game = FindObjectOfType<GameManager>();
    }


	void OnTriggerEnter(Collider other)
	{
        if (tag == "Bullet")
        {
            if (other.tag == "Hostile")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Debug.Log(other.gameObject.name + " destroyed " + gameObject.name, this);
                score.AddKill();
            }
            else if (other.tag == "Friendly")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Debug.Log(other.gameObject.name + " destroyed " + gameObject.name, this);
                score.AddFriendKill();
            }
        }
        else if (tag == "Player")
        {
            if (other.tag == "Hostile" || other.tag == "HostileBullet" || other.tag == "Friendly")
            {
                game.Lose();
            }
            else if (other.tag == "Target")
            {
                game.Win();
            }
        }
	}
}
