using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutDestruction : MonoBehaviour {

	// Use this for initialization
	public float timeOut = 3.0f;
	private float timeup;
	private AudioSource adsrc;
	// Update is called once per frame
	void Start()
	{
		adsrc = this.GetComponent<AudioSource> ();
		timeup = Time.time + timeOut;
		adsrc.Play();
	}

	void Update () {
		
		if (timeup < Time.time)
			Destroy (this.gameObject);
	}
}
