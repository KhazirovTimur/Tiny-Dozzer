using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAll : MonoBehaviour
{
    // Start is called before the first frame update
    public void FullRestart()
    {
        PlayerPrefsManager.completedLevelsCount();
        SceneManager.LoadScene("LoadScene");
    }
}
