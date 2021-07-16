using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {
    //Fade object
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    //Menu container that has all the screen panels i.e. settings, credits, and shop
    public RectTransform menuContainer;
    public Transform settingsPanel;

    //Object to move screen panel positions
    private Vector3 desiredMenuPosition;

    // Main method
    void Start() {
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha = 1;

        InitShop();
        InitSettings();
    }

    // Update is called once per frame
    void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;

        //Menu Nav
        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f); 
    }

    private void InitShop(){

    }

    //Initialize settings panel
    private void InitSettings(){
        if (settingsPanel == null) 
            Debug.Log("You did not assign the lvel panel in inspectior");

        int i = 0;
        foreach (Transform t in settingsPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnSettingsSelect(currentIndex));

            i++;
        }

    }
    
    private void OnSettingsSelect(int currentIndex) {

    }

    //Navigating to dif panel screens
    private void NavtigateTo(int menuIndex) {
        switch (menuIndex)
        {
            default:
                case 0:
                desiredMenuPosition = Vector3.zero;
                break;
            //Settings    
            case 1: desiredMenuPosition = Vector3.right * 1280;
            break;
            //Shop
            case 2: desiredMenuPosition = Vector3.left * 1280;
            break;
            //Credits
            case 3: desiredMenuPosition = Vector3.up * -650;
            break;
            //Controls
            case 4: desiredMenuPosition = Vector3.right * (1280 *  2);
            break;
        }
    }

    public void OnBackClick() {
        NavtigateTo(0);
        Debug.Log("Going back to main menu");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }

    public void OnCreditsClick() {
        NavtigateTo(3);
        Debug.Log("Credits button clicked");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }

    public void OnSettingsClick() {
        NavtigateTo(1);
        Debug.Log("Settings button clicked");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }

    public void OnPlayClick() {
        SceneManager.LoadScene("Game");
        Debug.Log("Play button clicked");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }

    public void OnShopClick() {
        NavtigateTo(2);
        Debug.Log("Shop button clicked");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }
    public void OnControlClick()
    {
        NavtigateTo(4);
        Debug.Log("Control configuration button clicked");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }
    public void OnTutorialClick()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Tutorial button clicked");
        SFXPlayer.sfxInstance.Audio.PlayOneShot(SFXPlayer.sfxInstance.Click);
    }
}
