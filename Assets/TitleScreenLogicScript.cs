using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenLogicScript : MonoBehaviour
{
    private string toggleState;
    private GameObject backgroundSound;
    private AudioSource bgSFX;


    private void Awake()
    {
        if (BGSoundScript.instance)
        {
            backgroundSound = GameObject.FindGameObjectWithTag("BGSound");
        }
    }
    private void Start()
    {
        toggleState = PlayerPrefs.GetString("toggleState");
        if (backgroundSound)
        {
            bgSFX = backgroundSound.GetComponent<AudioSource>();
            if (bool.Parse(toggleState) == false)
            {
                bgSFX.mute = true;
            }
            else
            {
                bgSFX.mute = false;
            }

        }

    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void sfxSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void changeControl()
    {
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
