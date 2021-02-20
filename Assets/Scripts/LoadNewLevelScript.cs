using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewLevelScript : MonoBehaviour {

	public GameManager gm;
	public void loadNewLevel(){
		gm.NewLevel ();
	}
}
