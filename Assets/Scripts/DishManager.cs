using UnityEngine;
using System.Collections;

public class DishManager : MonoBehaviour {

	static public GameObject item1;
	static public GameObject item2;
	static public GameObject item3;
	static public GameObject item4;
	static public GameObject item5;	
	static public bool item1Filled = false;
	static public bool item2Filled = false;
	static public bool item3Filled = false;
	static public bool item4Filled = false;
	static public bool item5Filled = false;
	public static int orderItemCount = 0;
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
	private GameObject toServe;
	private float resetTimer = 1F;
	private float resetTime;
	private bool reset = true;
	
	// Use this for initialization
	void Start () {
		resetTime = Time.time - resetTimer * 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(resetTime + resetTimer < Time.time && reset){
			reset = false;
			orderItemCount = Mathf.FloorToInt(Random.value * 5) + 1;
			ChooseItems (orderItemCount);
		}
		if(orderItemCount == 0 && !reset){
			resetTime = Time.time;
			reset = true;
		}
	}
	
	void ChooseItems (int numItems){
		SetItem1();
		item1Filled = false;
		if(numItems > 1){
			SetItem2();
			item2Filled = false;
		}
		else{
			item2Filled = true;
		}
		if(numItems > 2){
			SetItem3();
			item3Filled = false;
		}
		else{
			item3Filled = true;
		}
		if(numItems > 3){
			SetItem4();
			item4Filled = false;
		}
		else{
			item4Filled = true;
		}
		if(numItems > 4){
			SetItem5();
			item5Filled = false;
		}
		else{
			item5Filled = true;
		}
	}
	
	void CreateItem (int numItem, GameObject toCreate){
		toCreate = (GameObject) GameObject.Instantiate(toCreate, new Vector3(-11.7F, 6.7F - 3 * (numItem - 1), -10), Quaternion.identity);
		toCreate.transform.eulerAngles = new Vector3(90, 180, 0);
		toCreate.transform.parent = transform;
	}
	
	void SetItem1 () {
		ChooseBase();
		item1 = toServe;
		CreateItem (1, item1);
	}
	void SetItem2 () {
		float randomValue = Random.value;
		if(randomValue < 0.2){
			ChooseVegetable();
			item2 = toServe;
		}
		else{
			ChooseMeat();
			item2 = toServe;
		}
		CreateItem (2, item2);
	}
	void SetItem3 () {
		float randomValue = Random.value;
		if(randomValue < 0.6){
			ChooseVegetable();
			item3 = toServe;
		}
		else if(randomValue < 0.7){
			ChooseMeat();
			item3 = toServe;
		}
		else{
			ChooseTopping();
			item3 = toServe;
		}
		CreateItem (3, item3);
	}
	void SetItem4 () {
		float randomValue = Random.value;
		if(randomValue < 0.3){
			ChooseVegetable();
			item4 = toServe;
		}
		else if(randomValue < 0.4){
			ChooseMeat();
			item4 = toServe;
		}
		else if(randomValue < 0.5){
			ChooseBase();
			item4 = toServe;
		}
		else{
			ChooseTopping();
			item4 = toServe;
		}
		CreateItem (4, item4);
	}
	void SetItem5 () {
		float randomValue = Random.value;
		if(randomValue < 0.3){
			ChooseVegetable();
			item5 = toServe;
		}
		else if(randomValue < 0.4){
			ChooseMeat();
			item5 = toServe;
		}
		else if(randomValue < 0.5){
			ChooseBase();
			item5 = toServe;
		}
		else{
			ChooseTopping();
			item5 = toServe;
		}
		CreateItem (5, item5);
	}
	
	void ChooseBase () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toServe = base1;
			break;
			
		case 1:
			toServe = base2;
			break;
			
		case 2:
			toServe = base3;
			break;
			
		case 3:
			toServe = base4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toServe = base1;
			break;
		}
	}
	
	void ChooseMeat () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toServe = meat1;
			break;
			
		case 1:
			toServe = meat2;
			break;
			
		case 2:
			toServe = meat3;
			break;
			
		case 3:
			toServe = meat4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toServe = base1;
			break;
		}	
	}
	
	void ChooseVegetable () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toServe = vegetable1;
			break;
			
		case 1:
			toServe = vegetable2;
			break;
			
		case 2:
			toServe = vegetable3;
			break;
			
		case 3:
			toServe = vegetable4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toServe = base1;
			break;
		}		
	}
	
	void ChooseTopping () {
		switch(Mathf.FloorToInt(Random.value*4)){
		case 0:
			toServe = topping1;
			break;
			
		case 1:
			toServe = topping2;
			break;
			
		case 2:
			toServe = topping3;
			break;
			
		case 3:
			toServe = topping4;
			break;
			
		default:
			Debug.Log("wrong item case");
			toServe = base1;
			break;
		}		
	}
}
