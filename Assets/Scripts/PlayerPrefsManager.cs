using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PlayerPrefsManager 
{
    public static void completedLevelsCount() 
    {
        if (PlayerPrefs.HasKey("Levels"))
        {
            int tmp = PlayerPrefs.GetInt("Levels");
            tmp = tmp + 1;
            PlayerPrefs.SetInt("Levels", tmp);
            PlayerPrefs.SetString("AddsShown", "no");
        }
        else {
            PlayerPrefs.SetInt("Levels", 2);   
        }
    }
    public static int levelToLoad() 
    {
        if (PlayerPrefs.HasKey("Levels"))
            return PlayerPrefs.GetInt("Levels");
        else
            return 1;
    }

    public static void ResetLevels()
    {
        PlayerPrefs.SetInt("Levels", 1);
    }

    public static void VideoAddWasShown()
    {
        PlayerPrefs.SetString("AddsShown", "yes");
    }

    public static bool ShowAds()
    {
        string tmp = PlayerPrefs.GetString("AddsShown");
        if (tmp is "yes")
            return false;
        else
            return true;
    }

}
