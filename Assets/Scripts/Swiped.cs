using UnityEngine;
using System.Collections;

public class Swiped : MonoBehaviour {
	
	private float returnTimer = 0.5F;
	private float hitTime;

	// Use this for initialization
	void Start () {
		hitTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(returnTimer + hitTime < Time.time){
			renderer.material.mainTextureOffset = new Vector2(0,0);
		}	
	}
	
	void TouchSensorSwipe () {
		renderer.material.mainTextureOffset = new Vector2(0,0.5F);
		hitTime = Time.time;
	}
}
