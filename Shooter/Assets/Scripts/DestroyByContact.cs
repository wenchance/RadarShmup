using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
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
	}
}
