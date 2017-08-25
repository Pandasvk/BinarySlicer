using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {
	public float Scoreadd;
	public float Timeadd;
	// Use this for initialization
	void Start () {
		/*if (collectable == null) {
			collectable = this.gameObject;
		}
		if (collectable.tag == "Bomb") {
			Scoreadd = -1;
			Timeadd = -5;
		}
		if (collectable.tag == "One") {
			Scoreadd = 2;
			Timeadd = 2;

		}
		if (collectable.tag == "Zero") {
			Scoreadd = 5;
			Timeadd = 0;
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float GetValueScore(){
		return Scoreadd;
	}

	public float GetValueTime(){
		return Timeadd;
	}
}
