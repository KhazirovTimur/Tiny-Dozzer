using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelScript : MonoBehaviour {

	public GameManager gm;
	public void loadNewLevel(){
		gm.RestartLevel ();
		
	}
}
