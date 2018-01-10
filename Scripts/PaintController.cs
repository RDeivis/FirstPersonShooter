using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintController : MonoBehaviour {

	float Timer = 10f;

	void Update () {
		if (Timer >= 0f) {
			Timer -= Time.deltaTime;
		} else {
			Destroy (this.gameObject);
		}
	}
}
