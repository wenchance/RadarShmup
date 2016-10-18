using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start () {
		UnityEngine.Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos.y = 0;
		transform.position = mousePos;
	}
}
