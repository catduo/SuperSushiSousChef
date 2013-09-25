using UnityEngine;
using System.Collections;

public class ObjectCreator : MonoBehaviour {

	public GameObject base1;
	private GameObject toCreate;
	private float overallTimer;
	private float overallResetTime = 1.5F;
	private float orderTimer = 10F;
	private float orderResetTime;
	private 
	
	// Use this for initialization
	void Start () {
		overallResetTime = Time.time;
		orderResetTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(overallResetTime + overallTimer < Time.time){
			CreateItem();
			overallResetTime = Time.time;
			overallTimer = Random.value * 2F;
		}
		if(orderResetTime + orderTimer < Time.time){
			CreateOrderItem();
			orderResetTime = Time.time;
			orderTimer = Random.value * 10F;
		}
		
	}
	
	void CreateItem () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			CreateBase();
			break;
			
		case 1:
			CreateBase();
			break;
			
		case 2:
			CreateBase();
			break;
			
		case 3:
			CreateBase();
			break;
			
		default:
			Debug.Log("wrong item case");
			CreateBase();
			break;
		}
	}
	
	void CreateBase () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toCreate = base1;
			break;
			
		case 1:
			toCreate = base1;
			break;
			
		case 2:
			toCreate = base1;
			break;
			
		case 3:
			toCreate = base1;
			break;
			
		default:
			Debug.Log("wrong item case");
			toCreate = base1;
			break;
		}
		toCreate = (GameObject) GameObject.Instantiate(toCreate, new Vector3(Random.value * 10 - 5, -20, -20), Quaternion.identity);
		toCreate.transform.eulerAngles = new Vector3(90, 180, 0);
	}
	
	void CreateMeat () {
		
	}
	
	void CreateVegetable () {
		
	}
	
	void CreateTopping () {
		
	}
	
	void CreateOrderItem () {
		CreateItem ();
	}
}
