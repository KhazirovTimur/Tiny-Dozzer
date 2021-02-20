using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BulldozerMover : MonoBehaviour {

	//GameObjects with AudioSources
	public GameObject BullIdle;
	public GameObject BullMove;
	
	//Bull Preferences
	private Rigidbody rb;
	private Vector3 move;
	public float speed = 10.0f;
	public float rotSpeed = 30.0f;
	public static bool ableToMove = true;


	//Camera
	private Transform cam;
	private Vector3 camForward;
	

	//Variables for destruction by barrel
	public GameObject Smoke;
	private bool destroyedByBarrel = false;
	private float afterDestrTime;
	private float smokeSpawnDelay = 0.0f;


	// Use this for initialization


	private void Awake()
	{
		// Set up the reference.



		// get the transform of the main camera
		if (Camera.main != null)
		{
			cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
		}
	}


	void Start () {
		rb = this.GetComponent<Rigidbody>();
		BullMove.SetActive (false);
		BullIdle.SetActive (true);
		ableToMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		//float h = CrossPlatformInputManager.GetAxis("Horizontal");
		//float v = CrossPlatformInputManager.GetAxis("Vertical");
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		

		if (!ableToMove) {
			h = 0;
		    v = 0;
			BullMove.SetActive (false);
			BullIdle.SetActive (false);
			//return;
		}



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
			

		if (move != new Vector3 (0, 0, 0) && ableToMove) {
			Vector3 newDir = Vector3.RotateTowards(transform.forward, move, 1.0f, 15.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
			BullMove.SetActive (true);
			BullIdle.SetActive (false);
		}

		if(GameManager.gm.gamepaused)
			BullIdle.SetActive(false);


		if (move == new Vector3 (0, 0, 0) && ableToMove) {
			rb.angularVelocity = new Vector3 (0, 0, 0);
			rb.velocity = new Vector3 (0, rb.velocity.y, 0);
			BullMove.SetActive (false);
			if(!GameManager.gm.gamepaused)
			BullIdle.SetActive (true);
		}

		if (destroyedByBarrel)
		{
			if (Time.time > smokeSpawnDelay) 
			{ 
			System.Random rnddd = new System.Random();
			float tmp1 = rnddd.Next(10, 80);
			float tmp2 = rnddd.Next(10, 80);
			tmp1 = tmp1 / 100;
			tmp2 = tmp2 / 100;
			Vector3 tmpp = new Vector3(tmp1, 0, tmp2);
			GameObject SmokeIdl = Instantiate(Smoke, transform.position + transform.forward / 2 + tmpp + transform.up, transform.rotation);
		    float tmp3 = rnddd.Next(10, 50);
		    tmp3 = tmp3 / 100;
			smokeSpawnDelay = Time.time + tmp3;

			}
			if (Time.time > afterDestrTime)
				GameManager.gm.GameOver();
		}

	    
	}



	void FixedUpdate(){
		if(ableToMove)
		rb.MovePosition ((Vector3)transform.position + (move * speed * Time.deltaTime));

	}


    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "ExplWave")
		{
			ableToMove = false;
			destroyedByBarrel = true;
			afterDestrTime = Time.time + 3.0f;
		}
	}
}
