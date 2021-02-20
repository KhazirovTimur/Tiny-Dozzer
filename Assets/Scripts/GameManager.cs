using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public GameObject cam;


	//All Canvas
	public GameObject WinScreen;
	public GameObject GameOverScreen;
	public GameObject JoystickCanvas;
	public GameObject InfoCanvas;
	public GameObject PauseCanvas;
	public GameObject StartCanvas;


	public string nextLevelToLoad;
	public string RestartToLoad;
	public Text score;
	public Text timeleft;
	public Text LevelName;
	public float timelef = 60.0f;
	Scene _scene;

	[HideInInspector]
	public bool gamepaused;
	[HideInInspector]
	public bool gameIsOver;

	
	private int TrashCount = 0;
	private AudioSource adsrc;
	List<TargetsBehaviourScript> targetsList = new List<TargetsBehaviourScript>();
	// Use this for initialization
	private void Awake()
    {
		if (gm == null)
			gm = this;
	}

    void Start () {
		DeactivateAllUI();
		if (StartCanvas)
			StartCanvas.SetActive(true);
		
		adsrc = cam.GetComponent<AudioSource>();
		_scene = SceneManager.GetActiveScene();
		LevelName.text = _scene.name;
		gameIsOver = false;
		gamepaused = false;
		GamePause();
		if (PauseCanvas)
			PauseCanvas.SetActive(false);
		
		targetsList = FindObjectsOfType<TargetsBehaviourScript>().ToList();
		TrashCount = targetsList.Count;

		for (int i = 0; i < targetsList.Count; i++)         //Setting TargetDestroy Listener from TargetsBehavior
			targetsList[i].OnDestroy += DestroyTarget;
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameIsOver) {
			if ( targetsList.Count == 0) {               // check to see if beat game
				WinLevel ();
			} else if (timelef < 0) {                   // check to see if timer has run out
				GameOver ();
			} else {                                    // game playing state, so update the timer
				timelef -= Time.deltaTime;
				timeleft.text = timelef.ToString ("0");
				                      
			}
		}
			
	}

	public void SetDefaltsAfterStart() 
	{
		if (InfoCanvas)
			InfoCanvas.SetActive(true);
		if (JoystickCanvas)
			JoystickCanvas.SetActive(true);
		if (StartCanvas)
			StartCanvas.SetActive(false);
		GamePause();
	}

	void CountScore() {  //output score in %
		float scoreCountFl = TrashCount-targetsList.Count;                  
		scoreCountFl = scoreCountFl / TrashCount * 100;   
		int tmpInt = (int)scoreCountFl;                   
		string ScoreString = tmpInt.ToString();           
		ScoreString = ScoreString + "%";	
		score.text = ScoreString;
		
	}

	public void WinLevel(){
		if (gameIsOver)
			return;
		adsrc.mute = true;
		BulldozerMover.ableToMove = false;
		gameIsOver = true;
		if (WinScreen)
			WinScreen.SetActive (true);
		if (InfoCanvas)
			InfoCanvas.SetActive(false);
		if(JoystickCanvas)
			JoystickCanvas.SetActive(false);
		PlayerPrefsManager.completedLevelsCount();
	}

	public void NewLevel(){
		SceneManager.LoadScene (nextLevelToLoad);
	}

	public void GameOver(){
		if (gameIsOver)
			return;
		gameIsOver = true;
		adsrc.mute = true;
		BulldozerMover.ableToMove = false;
		if (GameOverScreen)
			GameOverScreen.SetActive (true);
		if (InfoCanvas)
			InfoCanvas.SetActive(false);
		if (JoystickCanvas)
			JoystickCanvas.SetActive(false);
		if (WinScreen)
			WinScreen.SetActive(false);
	}

	public void RestartLevel(){
		
		SceneManager.LoadScene (RestartToLoad);
	}

	private void DestroyTarget(TargetsBehaviourScript target){  
		if (targetsList.Contains(target))
		{
			targetsList.Remove(target);
			Destroy(target.gameObject);
			CountScore();
		}
    }

    public void GamePause()
    {
		if(!gameIsOver)
		if (!gamepaused)
		{
			gamepaused = true;
			Time.timeScale = 0;
				if (JoystickCanvas)
					JoystickCanvas.SetActive(false);
				PauseCanvas.SetActive(true);
		}
		else {
			gamepaused = false;
			Time.timeScale = 1;
			PauseCanvas.SetActive(false);
				if (JoystickCanvas)
					JoystickCanvas.SetActive(true);
			}
	}

	void DeactivateAllUI() {
		{
			if (InfoCanvas)
				InfoCanvas.SetActive(false);
			if (JoystickCanvas)
				JoystickCanvas.SetActive(false);
			if (WinScreen)
				WinScreen.SetActive(false);
			if (GameOverScreen)
				GameOverScreen.SetActive(false);
			if (PauseCanvas)
				PauseCanvas.SetActive(false);
			if (StartCanvas)
				StartCanvas.SetActive(false);
		}
	}


}
