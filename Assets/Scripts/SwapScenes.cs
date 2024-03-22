using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "LevelOne")
        {
            MusicToPlay.instance.GetComponent<AudioSource>().Pause();
        }
        else if(SceneManager.GetActiveScene().name == "Level Two")
        {
            MusicToPlay.instance.GetComponent<AudioSource>().Pause();
        }
        else if (SceneManager.GetActiveScene().name == "Level Two")
        {
             MusicToPlay.instance.GetComponent<AudioSource>().Pause();
        }
        else if(SceneManager.GetActiveScene().name == "CutScene1")
        {
            MusicToPlay.instance.GetComponent<AudioSource>().Pause();
        }
        else if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            MusicToPlay.instance.GetComponent<AudioSource>().Pause();
        }
        
         
    }
}
