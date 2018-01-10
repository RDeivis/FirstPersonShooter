using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public GameObject target;
	public GameObject gameManager;

	private float timer = 10f;
	private bool dead = false;

	void OnCollisionEnter(Collision collision){
		if (!dead) {
			dead = true;
			target.transform.Rotate (new Vector3 (0, 90, 0));
			gameManager.GetComponent<GameManager> ().score += 1;
		}
	}

	void Update(){
		if (dead) {
			if (timer <= 0) {
				dead = false;
				target.transform.Rotate (new Vector3 (0, -90, 0));
				timer = 10f;
			} else {
				timer -= Time.deltaTime;
			}
		}
	}
}
