using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CamMover : MonoBehaviour {


	private Rigidbody rb;
	private Vector3 move;
	public float speed = 10.0f;
	private Transform cam;
	private Vector3 camForward;
	// Use this for initialization


	private void Awake()
	{
		// Set up the reference.


		// get the transform of the main camera

			cam = this.transform;
		
	}


	void Start () {
		//rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		if (cam != null)
		{
			// calculate camera relative direction to move:
			camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
			move = (v*camForward + h*cam.right).normalized;
		}
		else
		{
			// we use world-relative directions in the case of no main camera
			move = (v*Vector3.forward + h*Vector3.right).normalized;
		}

	
	
	}

	void FixedUpdate(){
		transform.Translate ((move * speed * Time.deltaTime));
	}
}
