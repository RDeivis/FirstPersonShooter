using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Material red;
	public Material green;
	public Material blue;

	public Material SplatRED;
	public Material SplatBLUE;
	public Material SplatGREEN;
	public Material SplatTextRED;
	public Material SplatTextBLUE;
	public Material SplatTextGREEN;

	public GameObject splatterRed;
	public GameObject splatterGreen;
	public GameObject splatterBlue;
	public GameObject success;

	private int color;

	void Start(){
		color = Random.Range (0, 3);
		if (color == 0) {
			gameObject.GetComponent<MeshRenderer> ().material = red;
		} else if (color == 1) {
			gameObject.GetComponent<MeshRenderer> ().material = green;
		} else if (color == 2) {
			gameObject.GetComponent<MeshRenderer> ().material = blue;
		}
	}

	void Update(){
		gameObject.transform.Translate (Vector3.forward * Time.deltaTime * 25f);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "Enemy") {
			GameObject splat = GameObject.CreatePrimitive (PrimitiveType.Cube);
			splat.transform.position = other.contacts [0].point;
			splat.transform.rotation = Quaternion.FromToRotation (Vector3.forward, other.contacts [0].normal);
			splat.transform.localScale = new Vector3 (1f, 1f, 0.0001f);
			splat.transform.Translate (Vector3.forward * 0.01f);
			splat.AddComponent<PaintController> ();
			splat.GetComponent<Collider> ().enabled = false;
			if (other.gameObject.tag == "Boxes")
				splat.transform.parent = other.gameObject.transform;

			if (other.collider.bounds.Contains (splat.transform.position)) {
				PushDecalAndCheckAgain (splat, other);
			}

			if (color == 0) {
				GameObject.Instantiate (splatterRed, splat.transform);
				if (Random.Range (0, 2) == 0) {
					splat.GetComponent<MeshRenderer> ().material = SplatRED;
				} else {
					splat.GetComponent<MeshRenderer> ().material = SplatTextRED;
				}
			} else if (color == 1) {
				GameObject.Instantiate (splatterGreen, splat.transform);
				if (Random.Range (0, 2) == 0) {
					splat.GetComponent<MeshRenderer> ().material = SplatGREEN;
				} else {
					splat.GetComponent<MeshRenderer> ().material = SplatTextGREEN;
				}
			} else if (color == 2) {
				GameObject.Instantiate (splatterBlue, splat.transform);
				if (Random.Range (0, 2) == 0) {
					splat.GetComponent<MeshRenderer> ().material = SplatBLUE;
				} else {
					splat.GetComponent<MeshRenderer> ().material = SplatTextBLUE;
				}
			}
		} else {
			GameObject.Instantiate (success, other.gameObject.transform);
		}
		Destroy (gameObject);
	}

	private void PushDecalAndCheckAgain(GameObject splat, Collision other){
		if (other.collider.bounds.Contains (splat.transform.position)) {
			splat.transform.Translate (Vector3.forward * 0.01f);
			PushDecalAndCheckAgain (splat, other);
		}
	}
}
