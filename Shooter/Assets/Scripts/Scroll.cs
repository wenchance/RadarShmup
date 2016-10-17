using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	void Update () {

		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime / 5f;
		mat.mainTextureOffset = offset;
	}
}
