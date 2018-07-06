using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FoodManager : MonoBehaviour {
	public GameObject food;
	public float delayTime = 1f;
	public float repeatRate = 3f;
	public Transform[] spawnPoints; //產生食物的點座標
	private bool catIsFull = false;

	private void catFullAction(){
		catIsFull = true;
	}

	private void OnEnable(){
		
	}

	private void OnDisable(){

	}

	public void Spawn(){
		if (catIsFull) {
			CancelInvoke ("Spawn");
			return;
		}
		int pointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (food, spawnPoints [pointIndex].position,spawnPoints [pointIndex].rotation);
	}

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Spawn", delayTime, repeatRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
