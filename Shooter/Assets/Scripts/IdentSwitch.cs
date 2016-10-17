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

	public float sightRadius = 10f;

	public bool hasbeenpinged = false;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform>() as Transform;
		audioSource = GetComponent<AudioSource > ();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (player.position, transform.position);
		if (dist <= sightRadius)
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
			audioSource.Play ();
		} else
			Friendly.SetActive (true);
	}
}
