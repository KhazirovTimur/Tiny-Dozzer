using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviourScript : MonoBehaviour
{
    public GameObject ExplWave;

    private Rigidbody rb;
    private Animator anim;
    private bool explodeStarted = false;
    private float timeLeft;
    private float timeLeftStart;
    private bool moved =false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
        explodeStarted = false;
        moved = false;
        timeLeftStart = Time.time + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 tmp = rb.velocity;
        if ((Time.time > timeLeftStart && !moved) && (Mathf.Abs(tmp.x) > 0.1 || Mathf.Abs(tmp.z) > 0.1))
        { explosion();
          explodeStarted = true;
          timeLeft = Time.time + 2.1f;
            moved = true;
            
        }

        if (explodeStarted && Time.time > timeLeft)
        {
            GameObject ExplWaveInit = Instantiate(ExplWave, transform.position, transform.rotation);
            explodeStarted = false;
            Destroy(this.gameObject);
        }
    }

    void explosion() 
    {
        anim.SetTrigger("Explode");
    }
}
