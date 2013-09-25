using UnityEngine;
using System.Collections;

public class SwipeCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter (Collision collision) { 
		collision.collider.SendMessage("Swipe");
	}
	
	void OnTriggerEnter (Collider other) {
		other.SendMessage("Swipe");
	}
	void OnTriggerStay (Collider other) {
		other.SendMessage("Swipe");
	}
}
