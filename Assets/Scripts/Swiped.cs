using UnityEngine;
using System.Collections;

public class Swiped : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		if(transform.position.x < -11){
			rigidbody.useGravity = false;
			collider.enabled = false;
		}
		else{
			rigidbody.AddForce(Random.value * 500 - 250, Random.value * 250 + 950, 0);
			rigidbody.AddTorque(new Vector3(0,0, Random.value *200 - 100));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -11){
			if(transform.position.y > 6F && DishManager.item1Filled){
				renderer.enabled = false;
			}
			else if(transform.position.y > 3F && transform.position.y < 5F && DishManager.item2Filled){
				renderer.enabled = false;
			}
			else if(transform.position.y > 0F && transform.position.y < 2F  && DishManager.item3Filled){
				renderer.enabled = false;
			}
			else if(transform.position.y > -3F && transform.position.y < -1F  && DishManager.item4Filled){
				renderer.enabled = false;
			}
			else if(transform.position.y > -6F && transform.position.y < -5F  && DishManager.item5Filled){
				renderer.enabled = false;
			}
			if(DishManager.orderItemCount == 0){
				Destroy(gameObject);
			}
		}
		if(transform.position.y < -25){
			Destroy (gameObject);
		}
	}
	
	void Swipe () {
		if(transform.position.x > -11){
			CheckOrder();
			renderer.enabled = false;
			collider.enabled = false;
		}
	}
	
	void CheckOrder () {
		if(!DishManager.item1Filled){
			if(DishManager.item1.transform.name + "(Clone)" == transform.name){
				Debug.Log ("item1swiped");
				DishManager.item1Filled = true;
				DishManager.orderItemCount --;
			}
		}
		if(!DishManager.item2Filled){
			if(DishManager.item2.transform.name + "(Clone)" == transform.name){
				Debug.Log ("item2swiped");
				DishManager.item2Filled = true;
				DishManager.orderItemCount --;
			}
		}
		if(!DishManager.item3Filled){
			if(DishManager.item3.transform.name + "(Clone)" == transform.name){
				Debug.Log ("item3swiped");
				DishManager.item3Filled = true;
				DishManager.orderItemCount --;
			}
		}
		if(!DishManager.item4Filled){
			if(DishManager.item4.transform.name + "(Clone)" == transform.name){
				Debug.Log ("item4swiped");
				DishManager.item4Filled = true;
				DishManager.orderItemCount --;
			}
		}
		if(!DishManager.item5Filled){
			if(DishManager.item5.transform.name + "(Clone)" == transform.name){
				Debug.Log ("item5swiped");
				DishManager.item5Filled = true;
				DishManager.orderItemCount --;
			}
		}
	}
	
	void ReverseXVelocity () {
		rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y, 0);
	}
}
