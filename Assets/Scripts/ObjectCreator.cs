using UnityEngine;
using System.Collections;

public class ObjectCreator : MonoBehaviour {

	public GameObject base1;
	public GameObject base2;
	public GameObject base3;
	public GameObject base4;
	public GameObject meat1;
	public GameObject meat2;
	public GameObject meat3;
	public GameObject meat4;
	public GameObject topping1;
	public GameObject topping2;
	public GameObject topping3;
	public GameObject topping4;
	public GameObject vegetable1;
	public GameObject vegetable2;
	public GameObject vegetable3;
	public GameObject vegetable4;
	public GameObject trash1;
	public GameObject trash2;
	public GameObject trash3;
	public GameObject trash4;
	private GameObject toCreate;
	private float overallTimer;
	private float overallResetTime = 1.5F;
	private float orderTimer = 1F;
	private float orderResetTime;
	private float trashTimer = 3F;
	private float trashResetTime;
	
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
			orderTimer = Random.value * 5F + 5F;
		}
		if(trashResetTime + trashTimer < Time.time){
			CreateTrashItem();
			trashResetTime = Time.time;
			trashTimer = Random.value * 4F;
		}
		
	}
	
	void CreateItem () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			CreateBase();
			break;
			
		case 1:
			CreateMeat();
			break;
			
		case 2:
			CreateVegetable();
			break;
			
		case 3:
			CreateTopping();
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
			toCreate = base2;
			break;
			
		case 2:
			toCreate = base3;
			break;
			
		case 3:
			toCreate = base4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toCreate = base1;
			break;
		}
		CreateIt (toCreate);
	}
	
	void CreateMeat () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toCreate = meat1;
			break;
			
		case 1:
			toCreate = meat2;
			break;
			
		case 2:
			toCreate = meat3;
			break;
			
		case 3:
			toCreate = meat4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toCreate = base1;
			break;
		}
		CreateIt (toCreate);		
	}
	
	void CreateVegetable () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toCreate = vegetable1;
			break;
			
		case 1:
			toCreate = vegetable2;
			break;
			
		case 2:
			toCreate = vegetable3;
			break;
			
		case 3:
			toCreate = vegetable4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toCreate = base1;
			break;
		}
		CreateIt (toCreate);		
	}
	
	void CreateTopping () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toCreate = topping1;
			break;
			
		case 1:
			toCreate = topping2;
			break;
			
		case 2:
			toCreate = topping3;
			break;
			
		case 3:
			toCreate = topping4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toCreate = base1;
			break;
		}
		CreateIt (toCreate);		
	}
	
	void CreateOrderItem () {
		float randomValue = Random.value * DishManager.orderItemCount;
		Debug.Log (randomValue);
		if(randomValue < 1){
			if(!DishManager.item1Filled){
				toCreate = DishManager.item1;
			}
			else if(!DishManager.item2Filled){
				toCreate = DishManager.item2;
			}
			else if(!DishManager.item3Filled){
				toCreate = DishManager.item3;
			}
			else if(!DishManager.item4Filled){
				toCreate = DishManager.item4;
			}
			else if(!DishManager.item5Filled){
				toCreate = DishManager.item5;
			}
		}
		else if(randomValue < 2){
			if(!DishManager.item2Filled){
				toCreate = DishManager.item2;
			}
			else if(!DishManager.item3Filled){
				toCreate = DishManager.item3;
			}
			else if(!DishManager.item4Filled){
				toCreate = DishManager.item4;
			}
			else if(!DishManager.item5Filled){
				toCreate = DishManager.item5;
			}
			else if(!DishManager.item1Filled){
				toCreate = DishManager.item1;
			}
		}
		else if(randomValue < 3){
			if(!DishManager.item3Filled){
				toCreate = DishManager.item3;
			}
			else if(!DishManager.item4Filled){
				toCreate = DishManager.item4;
			}
			else if(!DishManager.item5Filled){
				toCreate = DishManager.item5;
			}
			else if(!DishManager.item1Filled){
				toCreate = DishManager.item1;
			}
			else if(!DishManager.item2Filled){
				toCreate = DishManager.item2;
			}
		}
		else if(randomValue < 4){
			if(!DishManager.item4Filled){
				toCreate = DishManager.item4;
			}
			else if(!DishManager.item5Filled){
				toCreate = DishManager.item5;
			}
			else if(!DishManager.item1Filled){
				toCreate = DishManager.item1;
			}
			else if(!DishManager.item2Filled){
				toCreate = DishManager.item2;
			}
			else if(!DishManager.item3Filled){
				toCreate = DishManager.item3;
			}
		}
		else if(randomValue < 5){
			if(!DishManager.item5Filled){
				toCreate = DishManager.item5;
			}
			else if(!DishManager.item1Filled){
				toCreate = DishManager.item1;
			}
			else if(!DishManager.item2Filled){
				toCreate = DishManager.item2;
			}
			else if(!DishManager.item3Filled){
				toCreate = DishManager.item3;
			}
			else if(!DishManager.item4Filled){
				toCreate = DishManager.item4;
			}
		}
		else{
			Debug.Log ("out of order item range in Object Creator");
			toCreate = base1;
		}
		CreateIt (toCreate);
	}
	
	void CreateTrashItem () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toCreate = trash1;
			break;
			
		case 1:
			toCreate = trash2;
			break;
			
		case 2:
			toCreate = trash3;
			break;
			
		case 3:
			toCreate = trash4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toCreate = base1;
			break;
		}
		CreateIt (toCreate);
	}
	
	void CreateIt (GameObject toCreate) {
		toCreate = (GameObject) GameObject.Instantiate(toCreate, new Vector3(Random.value * 10 - 5, -20, -20), Quaternion.identity);
		toCreate.transform.eulerAngles = new Vector3(90, 180, 0);
		toCreate.transform.parent = transform;
	}
}
