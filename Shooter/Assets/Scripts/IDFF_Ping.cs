﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System.Collections.Generic;

public class IDFF_Ping : MonoBehaviour {

	[SerializeField]
	private float cooldown = 30.0f;
	[SerializeField]
	private int bogeysDetected = 3;

	private float cooldownTimer = 0f;

	public Text IDFFcoolDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButton ("Fire2") && cooldownTimer <= 0f) 
		{
			StartPing ();
			Debug.Log ("PIIIIIIIING", this);
		}

		if (cooldownTimer > 0f) {
			IDFFcoolDown.color = Color.red;
			IDFFcoolDown.text = "IDFF Charging";
			cooldownTimer -= Time.deltaTime;
		} else {
			IDFFcoolDown.color = Color.green;
			IDFFcoolDown.text = "IDFF Ready";
		}
	}

	public void StartPing ()
	{
		cooldownTimer = cooldown;

		IdentSwitch[] identities = Object.FindObjectsOfType<IdentSwitch>();
		int verified = 0;
		for (int i = 0; i < identities.Length; i++) {
			if (identities [i].hasbeenpinged == false) {
				verified++;
				identities [i].IDFF ();
			}
			if (verified >= bogeysDetected)
				break;
		} 
	}
}
