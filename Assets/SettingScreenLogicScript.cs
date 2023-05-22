using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingScreenLogicScript : MonoBehaviour
{
    private bool toggleState;
    private bool toggleState1;


    private string toggleCheck;
    private string toggleCheck1;

    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Toggle toggle1;
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
        if (toggle)
        {
            toggleState = toggle.isOn;
            PlayerPrefs.SetString("toggleState", toggleState.ToString());
            volumeCheck(toggleState);
        }
        if (toggle1)
        {
            toggleState1 = toggle1.isOn;
            PlayerPrefs.SetString("toggleState1", toggleState1.ToString());
            volumeCheck(toggleState);
        }
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
