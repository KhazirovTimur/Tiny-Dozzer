using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsBannerBehaviourScript : MonoBehaviour
{

    public string placementId = "Banner1";
    

    void Start()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        //while (!Advertisement.IsReady(placementId))
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
}