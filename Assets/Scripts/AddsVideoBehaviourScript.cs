using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsVideoBehaviourScript : MonoBehaviour
{

    public string placementId = "video";
    

    void Start()
    {
        if (PlayerPrefsManager.ShowAds() is true)
        {
            Advertisement.Show(placementId);
            PlayerPrefsManager.VideoAddWasShown();
        }
        
    }

  
}