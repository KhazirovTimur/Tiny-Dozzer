using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TargetsBehaviourScript : MonoBehaviour {

    public GameObject particles;



    private bool DeadWasZoneEntered = false;
	private Vector3 oldPos;
	private Vector3 dirr;
	private float checkDirTimer;
	public Action<TargetsBehaviourScript> OnDestroy = delegate { };
	
	
	Rigidbody rb;
    // Use this for initialization

    
    void Start () {
		oldPos = transform.position;
		rb = gameObject.GetComponent<Rigidbody> ();
		checkDirTimer = Time.time;
		//GameManager.gm.TrashIncrease();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (checkDirTimer < Time.time) {
			checkDirTimer = Time.time + 0.1f;
			dirr = transform.position - oldPos; //Counting moving dirrection
			oldPos = transform.position;          
		}
		if (transform.position.y < -100)
			TargetDestruction();
	}
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "ExplWave")
		{
			Vector3 tmp = this.transform.position - other.transform.position;
			rb.AddForce(tmp * 4000);
			
		}

		if (other.gameObject.tag == "DeadZone" && !DeadWasZoneEntered) {
			DeadWasZoneEntered = true;
			TargetDestruction();
			
		}


	}

	void TargetDestruction() {
		Instantiate(particles, this.gameObject.transform.position, new Quaternion(0, 0, 0, 1));
		OnDestroy.Invoke(this);
		//GameManager.gm.ScoreIncrease();
		Destroy(this.gameObject);
	}

	void OnCollisionExit(Collision other){
		
		if (other.gameObject.tag == "Player")
			rb.AddForce (dirr*600);
	}
}
