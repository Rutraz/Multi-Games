using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject SlimyPanel;
    public GameObject SoundyPanel;
    public GameObject RocketyPanel;
    public GameObject PintasPanel;


    //Panels
    public void GoToPanelSlimy()
    {
      
        SlimyPanel.SetActive(true);
        
    }
   
    public void GoToSoundyPanel()
    {

        SoundyPanel.SetActive(true);

    }

    public void GoToRocketyPanel()
    {

        RocketyPanel.SetActive(true);

    }

    public void GoToPintasPanel()
    {

        PintasPanel.SetActive(true);

    }

  




    //Game Scenes
    public void GoToSlimyScene()
    {
        SceneManager.LoadScene("Slimy");
    }

    public void GoToRocktyScene()
    {
        SceneManager.LoadScene("Rockty");
    }

    public void GoToSoundyScene()
    {
        SceneManager.LoadScene("Soundy");
    }

    public void GoToPintasScene()
    {
        SceneManager.LoadScene("Pintas");
    }



    //Main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}

