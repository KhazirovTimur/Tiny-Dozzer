using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsArrayBehaviourScript : MonoBehaviour
{
    Rigidbody[] Bricks;
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        Bricks = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < Bricks.Length; i++)
        {
            Bricks[i].isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
            return;
        if (other.gameObject.tag != "Trash")
        {
            for (int i = 0; i < Bricks.Length; i++)
            {
                Bricks[i].isKinematic = false;
            }

            triggered = true;
        }
    }
}
