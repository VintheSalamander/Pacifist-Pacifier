using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public BeatController beatController;
    public GameObject musicMinigame;
    public AudioSource babyCrying;
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
        if(controllingHuman.name == "MomBaby"){
            beatController.StartScroll(1);
        }else{
            beatController.StartScroll(0);
        }
        musicMinigame.SetActive(true);
        music.Play();
    }

    public void StopMusic(){
        if(music){
            music.Stop();
            musicMinigame.SetActive(false);

            if(controllingHuman){
                controllingHuman.DeactivateHuman(-5f);
            }
            beatController.StopScroll();
        }
    }

    public void StopBabyCry(){
        babyCrying.Stop();
    }
}
