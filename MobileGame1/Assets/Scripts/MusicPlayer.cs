using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer MusicPlayerInstance;

    private void Awake()
    {
        if(MusicPlayerInstance != null && MusicPlayerInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        MusicPlayerInstance = this;
        DontDestroyOnLoad(this);
    }

    public void Mute()
    {
        AudioListener.pause = true;
    }

    public void Unmute()
    {
        AudioListener.pause = false;
    }
}
