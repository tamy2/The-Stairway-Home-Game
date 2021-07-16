using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogotime = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Fade object
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Fade opacity 1 = 100% opacity, 0 = 0% opcaity
        fadeGroup.alpha = 1;

        //Fade time aiming for like 3 secs
        if(Time.time < minimumLogotime)
            loadTime = minimumLogotime;
        else 
            loadTime = Time.time;
    }

    private void Update() {
        //Fade in
        if(Time.time < minimumLogotime) {
            fadeGroup.alpha = 1 - Time.time;
        }

        //Fade out
        if(Time.time > minimumLogotime && loadTime != 0) {
            fadeGroup.alpha = Time.time - minimumLogotime;
            if(fadeGroup.alpha >= 1) {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
