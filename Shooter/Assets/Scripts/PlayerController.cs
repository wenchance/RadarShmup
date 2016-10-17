using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb;
	public float speed;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	public Camera cam;
	public Text shootCooldown;


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}



	void Update ()
	{
		int timeLeft;
		if (Time.time < nextFire) {
			shootCooldown.color = Color.red;
			shootCooldown.text = "Reloading";
		} else {
			shootCooldown.color = Color.green;
			shootCooldown.text = "Armed";
		}

		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
			mousePos.y = 0;

			Vector3 relMousePos = mousePos - shotSpawn.position;

			float rotation = Mathf.Acos(Mathf.Abs(relMousePos.z) / relMousePos.magnitude) * 180 / Mathf.PI; //arccos rel.z, rel.abs

			if (relMousePos.x / relMousePos.z < 0)
			{
				rotation = 180 - rotation;
			}
			if (relMousePos.x > 0)
			{
				rotation += 180;
			}

			Quaternion rotationQ = Quaternion.Euler(0, rotation, 0);

			nextFire = Time.time + fireRate;
			// GameObject clone = 
			Instantiate (shot, shotSpawn.position, rotationQ); //as GameObject;
		}
	}



	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
	}


}
