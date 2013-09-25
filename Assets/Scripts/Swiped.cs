using UnityEngine;
using System.Collections;

public class Swiped : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		rigidbody.AddForce(Random.value * 500 - 250, Random.value * 500 + 1000, 0);
		rigidbody.AddTorque(new Vector3(0,0, Random.value *200 - 100));
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -25){
			Destroy (gameObject);
		}
	}
	
	void Swipe () {
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.GetComponent<BoxCollider>().enabled = false;
	}

}
