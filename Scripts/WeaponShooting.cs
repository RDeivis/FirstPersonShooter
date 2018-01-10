using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponShooting : MonoBehaviour {

	public float timer = 0.25f;
	public GameObject bullet;
	public Transform nozzlePosition;
	public GameObject smoke;

	void Update () {
		timer -= Time.deltaTime;
		if (CrossPlatformInputManager.GetButton("Fire2")) {
			if (timer <= 0) {
				Fire ();
				timer = 0.25f;
			}
		}
	}

	private void Fire(){
		GameObject.Instantiate (bullet, nozzlePosition.position, nozzlePosition.rotation);
		smoke.SetActive (false);
		smoke.SetActive (true);
	}
}
