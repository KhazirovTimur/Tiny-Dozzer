using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeOutLoadScene : MonoBehaviour
{

    public float Timeout = 3.0f;
    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > Timeout)
            SceneManager.LoadScene(LevelToLoad);
    }
}
