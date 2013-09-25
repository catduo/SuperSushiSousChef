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
		collision.collider.SendMessage("Swipe", SendMessageOptions.DontRequireReceiver);
	}
	
	void OnTriggerEnter (Collider other) {
		other.SendMessage("Swipe", SendMessageOptions.DontRequireReceiver);
	}
	void OnTriggerStay (Collider other) {
		other.SendMessage("Swipe", SendMessageOptions.DontRequireReceiver);
	}
}
