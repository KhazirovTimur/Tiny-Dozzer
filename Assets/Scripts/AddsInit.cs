using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsInit : MonoBehaviour
{
    public string gameId = "3891621";
    public bool testMode = false;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

  
}
