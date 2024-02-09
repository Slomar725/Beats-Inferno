using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SendToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("StoryOrSelect");
    }
    public void HelpScene()
    {
        SceneManager.LoadScene("Help");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void StoryScene()
    {
        SceneManager.LoadScene("CutScene1");
    }
    public void FreePlayMode()
    {
        SceneManager.LoadScene("FreePlay");
    }
    public void SkipSceneOne()
    {
        SceneManager.LoadScene("Yesman");
    }
    public void FreePlayBack()
    {
        SceneManager.LoadScene("StoryOrSelect");
    }
    
}
