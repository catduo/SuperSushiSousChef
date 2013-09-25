using UnityEngine;
using System.Collections;

public class Swiped : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		rigidbody.AddForce(Random.value * 500 - 250, Random.value *500 + 500, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Swipe () {
		Debug.Log ("swipe");
	}
	
	void OnCollisionEnter (Collision collision){
		if (collision.collider.name == "SwipeCapsule"){
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
