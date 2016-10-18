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
    [Range(0,1)]
    public float hostileChance;

    private GameObject actualObject;

	private Transform player;

	public float sightRadius = 10f;

	public bool hasbeenpinged = false;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform>() as Transform;
		audioSource = GetComponent<AudioSource > ();
        if (Random.value < hostileChance)
        {
            actualObject = Hostile;
            tag = "Hostile";
        }
        else
        {
            actualObject = Friendly;
            tag = "Friendly";
        }
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
        actualObject.SetActive(true);
	}
}
