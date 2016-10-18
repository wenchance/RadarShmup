using UnityEngine;
using System.Collections;


public class EnemyManager : MonoBehaviour {

	public GameObject identity;
	public GameObject hostileBullet;
	public float fireRate;
	private Vector3 spawnPosition = Vector3.zero;
	private Vector3 spawnRotation = Vector3.forward;
	[HeaderAttribute("Screen Size")]
	[SerializeField]
	private float topEdge = 10f;
	[SerializeField]
	private float edgeWidth = 10f;
	public float spawnRate = 15f;
	private float nextSpawn = 0f;
	public float maxSpawnRate = 1f;
	public float evasive = 3f;
	public float evasionFreq = 5f;
	public float moveSpeed = 5f;
	public float deviation = 0.2f;
	public Transform target;
	private float initialDistance;

	public GUIText restartText;
	public GUIText gameOverText;

	//public GUIText killsText;
	//private int kills;

	private bool gameOver;
	private bool restart;



	// Use this for initialization
	void Start () {
		/*gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";*/
		/*kills = 0;
		UpdateKills ();*/

		initialDistance = Vector3.Distance (target.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			spawnPosition = new Vector3 (Random.Range (transform.position.x - edgeWidth / 2.0f, transform.position.x + edgeWidth / 2.0f), 0f, transform.position.z + topEdge + 1f); 
			spawnRotation = new Vector3 (Random.Range(-deviation, deviation), 0f, 1f);
			Instantiate (identity, spawnPosition, Quaternion.Euler (spawnRotation));
			float dist = Vector3.Distance (target.position, transform.position);
			nextSpawn += Mathf.Lerp(maxSpawnRate, spawnRate, dist / initialDistance);
			//spawnRate *= 0.75f;
		} 
		if (spawnRate < maxSpawnRate) {
			spawnRate = maxSpawnRate;
		}

		/*if (gameOver) {
			restartText.text = "Press 'R' for Restart";
		}*/
	}

	void OnDrawGizmos (){
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (new Vector3(transform.position.x - edgeWidth / 2.0f, transform.position.y, transform.position.z + topEdge), new Vector3(transform.position.x + edgeWidth / 2.0f, transform.position.y, transform.position.z + topEdge));
	}

	/*public void AddKills (int newKillsValue){
		kills += newKillsValue;
		UpdateKills ();
	}

	void UpdateKills () {
		killsText.text = "Kills: " + kills;
	}*/

	/*public void GameOver (){
		gameOverText.text = "Mission Failure";
		gameOver = true;
	}*/
}
