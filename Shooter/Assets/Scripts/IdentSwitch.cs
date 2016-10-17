using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class IdentSwitch : MonoBehaviour {

	[SerializeField]
	private GameObject Hostile;
	[SerializeField]
	private GameObject Friendly;
	[SerializeField]
	private GameObject Bogey;

	private Transform player;

	public bool hasbeenpinged = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform>() as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (player.position, transform.position);
		if (dist <= 5f)
			IDFF ();
	}

	public void IDFF ()
	{
		if (hasbeenpinged == true)
			return;
		Bogey.SetActive (false);
		hasbeenpinged = true;
		float randomizer = Random.Range (0f, 1f);
		if (randomizer >= .5f) {
			Hostile.SetActive (true);
			gameObject.GetComponent<AutoMoveAndRotate> ().enabled = false;
		} else
			Friendly.SetActive (true);
	}
}
