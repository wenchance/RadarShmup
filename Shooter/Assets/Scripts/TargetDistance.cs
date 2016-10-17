using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetDistance : MonoBehaviour {

	public Text distanceText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		distanceText.text = "Target Distance " + transform.position.z.ToString ("0.0");
	}
}
