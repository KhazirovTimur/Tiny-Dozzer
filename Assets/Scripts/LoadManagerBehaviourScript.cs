using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManagerBehaviourScript : MonoBehaviour
{
    private string LevelName = "Level";
    public int MaxLevel = 16;
    // Start is called before the first frame update
    void Start()
    {
        int tmp = PlayerPrefsManager.levelToLoad();
        if (tmp >= MaxLevel + 1)
        { tmp = 1;
            PlayerPrefsManager.ResetLevels();
        }
        string tmp1 = tmp.ToString();
        LevelName = LevelName + tmp1;
        SceneManager.LoadScene(LevelName);
    }

  
    
}
