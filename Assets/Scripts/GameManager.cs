using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject [] spawnable;
	private float nextSpawnTime;
	public float spawnRate = 5;
	private float Points = 0;
	private float TimeLeft= 60;
	public Text ScoreText;
	public Text TimeText; 

	// Use this for initialization
	void Start () {
		nextSpawnTime = Time.time + spawnRate;
		Debug.Log (nextSpawnTime);

	}
	
	// Update is called once per frame
	void Update () {
		TimeLeft -= Time.deltaTime;
		TimeText.text = "Time left: " + (int)TimeLeft;
		if (TimeLeft <= 0) {
			Application.Quit();
		}
		if (Time.time >= nextSpawnTime) {
			int num = RandomGen();
			if (num >= 8) {
				//spawn v pravo
				SpawnCollectable (13.5f, -1.5f, 0, -15, 5, 0);
				Debug.Log ("spawnujem pravy");
			}
			if (num<=2){
				SpawnCollectable (-13.5f, -1.5f, 0,15,5,0);
				Debug.Log ("spawnujem lavy");
				// spawn vlavo
			}
			if(num>2 & num<8){
				SpawnCollectable (Random.Range(-8,8), -5.5f, 0,Random.Range(-2,2),15,0);
				//spawn dole
				Debug.Log ("spawnujem dolny");
			}
			nextSpawnTime = Time.time + spawnRate;
			}
			

	}

	int RandomGen(){
		return Random.Range (0, 10);
		}

	void SpawnCollectable(float x, float y,float z,float x1,float y1,float z1){
		int what = RandomGen(); 
		Vector3 spawnPosition;
		GameObject spawnedObject;
		spawnPosition.x = x;
		spawnPosition.y = y;
		spawnPosition.z = z;

		if (what >= 8) {
			spawnedObject = Instantiate (spawnable [2], spawnPosition, Random.rotation) as GameObject;
	
			spawnedObject.GetComponent<Rigidbody> ().AddForce (x1, y1, z1, ForceMode.Impulse);
			//Debug.Log ("Sila");
		}
		if( what<=3){
			spawnedObject = Instantiate (spawnable [1], spawnPosition, Random.rotation) as GameObject;

			spawnedObject.GetComponent<Rigidbody> ().AddForce (x1, y1, z1, ForceMode.Impulse);
			//Debug.Log ("Sila");
		}
		if( what>3 & what<8){
			spawnedObject = Instantiate (spawnable [0], spawnPosition, Random.rotation) as GameObject;

			spawnedObject.GetComponent<Rigidbody> ().AddForce (x1, y1, z1, ForceMode.Impulse);
			//Debug.Log ("Sila");
		}

	}

	public void ChangeScore(CollectableScript collectable){
		Points += collectable.GetValueScore();
		TimeLeft += collectable.GetValueTime();
		ScoreText.text = "Score : " + Points;
	}

}
