using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public string playEasyLevel;
    public string playNormalLevel;
    public string playHardLevel;
    public GameObject modeScreen;
    public GameObject optionsScreen;
    public GameObject howToScreen;

    //Open mode Menu
    public void OpenMode()
    {
        modeScreen.SetActive(true);
    }
    //Close mode menu
    public void CloseMode()
    {
        modeScreen.SetActive(false);
    }
    //Play easy level
    public void PlayEasy()
    {
        SceneManager.LoadScene(playEasyLevel);
    }
    //Play normal level
    public void PlayNormal()
    {
        SceneManager.LoadScene(playNormalLevel);
    }
    //Play hard level
    public void PlayHard()
    {
        SceneManager.LoadScene(playHardLevel);
    }
    //Open options menu
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    //Close options menu
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
    //Open how to menu
    public void OpenHowTo()
    {
        howToScreen.SetActive(true);
    }
    //Close how to menu
    public void CloseHowTo()
    {
        howToScreen.SetActive(false);
    }
    //Quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
