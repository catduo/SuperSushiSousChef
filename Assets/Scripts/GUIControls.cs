using UnityEngine;
using System.Collections;

public class GUIControls : MonoBehaviour {
	
	private GameObject pauseButton;
	private GameObject muteButton;
	private GameObject mainCamera;
	private GameObject scoreText;
	private GameObject comboText;
	private GameObject scoreScreen;
	private GameObject FTUE;
	private AudioSource audioSource;
	static public int score;
	static public int bonusMultiplier;
	static public int hitCount;
	private bool paused;
	private int topScore;
	private bool gameOver = false;
	static public bool ftue;
	private int ftueLocation = -1;
	private float touchSpeed;
	private Vector3 previousPosition = new Vector3 (1000,1000,1000);
	private float swipeThreshhold = 10;
	private LineRenderer drawSwipe;
	private int vertexCount = 0;
	private int vertexMax = 5;
	private GameObject capsule;
	private Vector3 screenToWorldCurrent;
	public AudioClip swish1;
	public AudioClip swish2;
	public AudioClip swish3;
	public AudioClip swish4;
	public AudioClip swish5;
	public AudioClip swish6;
	public AudioClip swish7;
	public AudioClip swish8;
	public AudioClip swish9;
	public AudioClip swish10;
	public AudioClip swish11;
	public AudioClip swish12;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("FTUE") != 1){
			ftue = true;
			Time.timeScale = 1;
		}
		else{
			ftue = false;
		}
		topScore = PlayerPrefs.GetInt("TopScore");
		mainCamera = GameObject.Find("MainCamera");
		FTUE = GameObject.Find("FTUE");
		pauseButton = GameObject.Find("PauseButton");
		muteButton = GameObject.Find("MuteButton");
		scoreScreen = GameObject.Find("ScoreScreen");
		scoreText = GameObject.Find("Score");
		comboText = GameObject.Find("ComboText");
		drawSwipe = transform.GetComponent<LineRenderer>();
		audioSource = transform.GetComponent<AudioSource>();
		drawSwipe.SetVertexCount(0);
		capsule = GameObject.Find ("SwipeCapsule");
		/*
		pauseButton.renderer.material.mainTextureOffset = new Vector2(0, 0.5F);
		muteButton.renderer.material.mainTextureOffset = new Vector2(0.25F, 0.5F);
		FTUETap ();
		*/
	}
	
	// Update is called once per frame
	void Update () {
		/*fade out the combo text
		if(comboText.GetComponent<TextMesh>().color.a > 0){
			comboText.GetComponent<TextMesh>().color = new Color(comboText.GetComponent<TextMesh>().color.r, comboText.GetComponent<TextMesh>().color.g, comboText.GetComponent<TextMesh>().color.b, comboText.GetComponent<TextMesh>().color.a - 0.05F);
		}
		*/
		//find everything that has a touch initiated on it and let it know
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began){
				previousPosition = touch.position;
	            Ray ray = Camera.main.ScreenPointToRay(touch.position);
	            RaycastHit objectTouched ;
	            if (Physics.Raycast (ray, out objectTouched)) {
	                 objectTouched.transform.SendMessage("Tap", SendMessageOptions.DontRequireReceiver);
	            }
			}
			//create a collision with everything that is swiped by touch
			if(touch.phase == TouchPhase.Moved){
				if(previousPosition != new Vector3 (1000,1000,1000) && Vector3.Distance(previousPosition, touch.position) > swipeThreshhold && vertexCount < vertexMax){
					drawSwipe.SetVertexCount(vertexCount+1);
					previousPosition = mainCamera.camera.ScreenToWorldPoint(previousPosition);
					screenToWorldCurrent = mainCamera.camera.ScreenToWorldPoint(touch.position);
					drawSwipe.SetPosition(vertexCount, new Vector3(screenToWorldCurrent.x, screenToWorldCurrent.y, -20F));
					capsule.transform.position = new Vector3(previousPosition.x + (screenToWorldCurrent.x - previousPosition.x) / 2, previousPosition.y + (screenToWorldCurrent.y - previousPosition.y) / 2, -20F);
	       			capsule.transform.LookAt(new Vector3(previousPosition.x, previousPosition.y, -20F));
					capsule.transform.Rotate (new Vector3 (90,0,0));
	       			capsule.transform.localScale = new Vector3(1F, (screenToWorldCurrent - previousPosition).magnitude/2, 1F);
					vertexCount++;
					previousPosition = touch.position;
					if(vertexCount == 2){
						RandomSwish();
						audioSource.Play();
					}
				}
				else{
					capsule.transform.position = new Vector3 (1000,1000,1000);
					previousPosition = touch.position;
					drawSwipe.SetVertexCount(0);
					vertexCount = 0;
				}
			}
		}
		//find everything that has the mouse click on it and let it know
		if(Input.GetMouseButtonDown(0)){
			Vector3 simTouch = Input.mousePosition;
	        Ray simRay = Camera.main.ScreenPointToRay(simTouch);
	        RaycastHit objectTouchedSim ;
	        if (Physics.Raycast (simRay, out objectTouchedSim)) {
	             objectTouchedSim.transform.SendMessage("Tap", SendMessageOptions.DontRequireReceiver);
	        }
		}
		//create a collision with everything that is swiped by mouse
		if(Input.GetMouseButton(0)){
			if(previousPosition != new Vector3 (1000,1000,1000) && Vector3.Distance(previousPosition, Input.mousePosition) > swipeThreshhold && vertexCount < vertexMax){
				drawSwipe.SetVertexCount(vertexCount+1);
				previousPosition = mainCamera.camera.ScreenToWorldPoint(previousPosition);
				screenToWorldCurrent = mainCamera.camera.ScreenToWorldPoint(Input.mousePosition);
				drawSwipe.SetPosition(vertexCount, new Vector3(screenToWorldCurrent.x, screenToWorldCurrent.y, -20F));
				capsule.transform.position = new Vector3(previousPosition.x + (screenToWorldCurrent.x - previousPosition.x) / 2, previousPosition.y + (screenToWorldCurrent.y - previousPosition.y) / 2, -20F);
       			capsule.transform.LookAt(new Vector3(previousPosition.x, previousPosition.y, -20F));
				capsule.transform.Rotate (new Vector3 (90,0,0));
       			capsule.transform.localScale = new Vector3(1F, (screenToWorldCurrent - previousPosition).magnitude/2, 1F);
				vertexCount++;
				previousPosition = Input.mousePosition;
				if(vertexCount == 2){
					RandomSwish();
					audioSource.Play();
				}
			}
			else{
				capsule.transform.position = new Vector3 (1000,1000,1000);
				previousPosition = Input.mousePosition;
				drawSwipe.SetVertexCount(0);
				vertexCount = 0;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			capsule.transform.position = new Vector3 (1000,1000,1000);
			previousPosition = new Vector3 (1000,1000,1000);
			drawSwipe.SetVertexCount(0);
			vertexCount = 0;
		}
	}
	
	//when pause is hit pause the game and open the menu, when hit again take down the menu
	void PauseButtonTap () {
		if(paused){
			Time.timeScale = 1;
			paused = false;
			pauseButton.renderer.material.mainTextureOffset = new Vector2(pauseButton.renderer.material.mainTextureOffset.x, 0.5F);
		}
		else{
			paused = true;
			Time.timeScale = 0;
			pauseButton.renderer.material.mainTextureOffset = new Vector2(pauseButton.renderer.material.mainTextureOffset.x, 0);
		}
	}
	//when mute is hit change the enabled state of the audio listener
	void MuteButtonTap () {
		if(AudioListener.volume == 0){
			AudioListener.volume = 1;
			muteButton.renderer.material.mainTextureOffset = new Vector2(muteButton.renderer.material.mainTextureOffset.x, 0.5F);
		}
		else{
			AudioListener.volume = 0;
			muteButton.renderer.material.mainTextureOffset = new Vector2(muteButton.renderer.material.mainTextureOffset.x, 0);
		}
	}
	//update the score text
	void UpdateScore () {
		scoreText.GetComponent<TextMesh>().text = "Score: " + score.ToString();
	}
	
	//when a combo happens display the combo count
	void Combo () {
	}
	
	//when the game ends put up a menu that lets you restart
	void GameOver(){
		ftue = false;
		Time.timeScale = 0;
		if(gameOver == false){
			if(topScore < 10){
				topScore = score;
			}
			else if(score > topScore){
				topScore = score;
			}
			PlayerPrefs.SetInt("TopScore", topScore);
			GameObject.Find ("HighScore").GetComponent<TextMesh>().text = "High Score: " + topScore.ToString();
			GameObject.Find ("ThisScore").GetComponent<TextMesh>().text = "This Round: " + score.ToString();
			scoreScreen.transform.position -= new Vector3(100,0,0);
			gameOver = true;
		}
	}
	
	void ScoreScreenTap () {
		scoreScreen.transform.position += new Vector3(100,0,0);
		Time.timeScale = 1;
		score = 0;
		GameObject.Find ("Plants").SendMessage("Start");
		GameObject.Find ("Clouds").SendMessage("Reset");
		gameOver = false;
	}
	
	void FTUETap () {
		if(PlayerPrefs.GetInt("FTUE") == 1){
			Destroy (FTUE);
		}
		ftueLocation++;
		if(ftueLocation > 6){
			Destroy (FTUE);
			Time.timeScale = 1;
			PlayerPrefs.SetInt("FTUE",1);
		}
		else{
			for(int i = 0; i < 7; i++){
				if(i == ftueLocation){
					FTUE.transform.GetChild(i).renderer.enabled = true;
				}
				else{
					FTUE.transform.GetChild(i).renderer.enabled = false;
				}
			}
		}
	}
	
	void RandomSwish () {
		switch(Mathf.FloorToInt(Random.value * 12)){
		case 0:
			audioSource.clip = swish1;
			break;
			
		case 1:
			audioSource.clip = swish2;
			break;
			
		case 2:
			audioSource.clip = swish3;
			break;
			
		case 3:
			audioSource.clip = swish4;
			break;
			
		case 4:
			audioSource.clip = swish5;
			break;
			
		case 5:
			audioSource.clip = swish6;
			break;
			
		case 6:
			audioSource.clip = swish7;
			break;
			
		case 7:
			audioSource.clip = swish8;
			break;
			
		case 8:
			audioSource.clip = swish9;
			break;
			
		case 9:
			audioSource.clip = swish10;
			break;
			
		case 10:
			audioSource.clip = swish11;
			break;
			
		case 11:
			audioSource.clip = swish12;
			break;
			
		default:
			audioSource.clip = swish1;
			break;
		}
	}
}
