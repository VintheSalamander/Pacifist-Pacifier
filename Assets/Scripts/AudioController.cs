using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public BeatController beatController;
    public GameObject musicMinigame;
    public static AudioController instance;
    private Human controllingHuman;
    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        musicMinigame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHuman(Human setHuman){
        if(setHuman){
            music = setHuman.GetMusic();
        }else{
            music = null;
        }
        controllingHuman = setHuman;
    }

    public void StartMusic(){
        beatController.StartScroll();
        musicMinigame.SetActive(true);
        music.Play();
    }

    public void StopMusic(){
        music.Stop();
        musicMinigame.SetActive(false);

        if(controllingHuman){
            controllingHuman.DeactivateHuman(-5f);
        }
        beatController.StopScroll();
    }
}
