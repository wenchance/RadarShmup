using UnityEngine;
using System.Collections;

public class HostileAction : MonoBehaviour {

	private Transform identityTransform;
	private GameObject bullet;
	private Transform player;
	private float fireRate;
	private float nextFire = 0f;
	private float evasive;
	private float evasionFreq;
	private float moveSpeed;
	private Vector3 moveDir;


	// Use this for initialization
	void Start () {
		identityTransform = transform.parent;
		bullet = GameObject.Find ("EnemyManager").GetComponent<EnemyManager>().hostileBullet;
		fireRate = GameObject.Find ("EnemyManager").GetComponent<EnemyManager>().fireRate;
		player = GameObject.Find ("Player").GetComponent<Transform> ();
		evasive = GameObject.Find ("EnemyManager").GetComponent<EnemyManager>().evasive;
		evasionFreq = GameObject.Find ("EnemyManager").GetComponent<EnemyManager>().evasionFreq;
		moveSpeed = GameObject.Find ("EnemyManager").GetComponent<EnemyManager>().moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		moveDir = new Vector3 (evasive * Mathf.Sin (Time.time / evasionFreq), 0f, (-moveSpeed));
		identityTransform.Translate (moveDir * Time.deltaTime, Space.Self);

		if (Time.time > nextFire) {
			Vector3 relativePos = player.position - transform.position;
			Quaternion rotationq = Quaternion.LookRotation (relativePos);
			Instantiate (bullet, transform.position, rotationq);
			nextFire = Time.time + fireRate;
		}

	}
}
