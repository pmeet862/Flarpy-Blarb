using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingScreenLogicScript : MonoBehaviour
{
    public bool toggleState;
    public bool toggleState1;


    string toggleCheck;
    string toggleCheck1;

    public Toggle toggle;
    public Toggle toggle1;
    private GameObject backgroundSound;
    private AudioSource bgSFX;

    private void Awake()
    {
        if (BGSoundScript.instance)
        {
            backgroundSound = GameObject.FindGameObjectWithTag("BGSound");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        toggleCheck = PlayerPrefs.GetString("toggleState");
        toggle.isOn = bool.Parse(toggleCheck);
        toggleCheck1 = PlayerPrefs.GetString("toggleState1");
        toggle1.isOn = bool.Parse(toggleCheck1);
    }

    // Update is called once per frame
    void Update()
    {
        toggleState = toggle.isOn;
        PlayerPrefs.SetString("toggleState", toggleState.ToString());
        toggleState1 = toggle1.isOn;
        PlayerPrefs.SetString("toggleState1", toggleState1.ToString());
        volumeCheck(toggleState);
    }

    void volumeCheck(bool toggleState)
    {
        if (backgroundSound)
        {
            bgSFX = backgroundSound.GetComponent<AudioSource>();
            if (toggleState == false)
            {
                bgSFX.mute = true;
            }
            else
            {
                bgSFX.mute = false;
            }

        }

    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
