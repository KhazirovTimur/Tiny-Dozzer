using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutDestructionBarExpl : MonoBehaviour {

	// Use this for initialization
	public float timeOut = 0.5f;
	private float timeup;
	// Update is called once per frame
	void Start()
	{
		timeup = Time.time + timeOut;
	}

	void Update () {
		
		if (timeup < Time.time)
			Destroy (this.gameObject);
	}
}
