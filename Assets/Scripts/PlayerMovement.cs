using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameObject klb;
	public float speed = 10;
	public GameManager gm;

	private Vector3 oldPos ;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
		oldPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (klb) {
			newPos = new Vector3 (klb.transform.position.x - oldPos.x, klb.transform.position.y - oldPos.y, 0);
			if (oldPos.x + newPos.x * speed > -12 && oldPos.x + newPos.x * speed < 12 && oldPos.y + newPos.y * speed > -4.5 && oldPos.y + newPos.y * speed < 6) {
				transform.position = oldPos + newPos * speed;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Bomb" || other.tag == "One" || other.tag == "Zero") {
			gm.ChangeScore (other.gameObject.GetComponent<CollectableScript>());

		}
		Destroy (other.gameObject);
		//Debug.Log ("Destroys player");
	}
}
