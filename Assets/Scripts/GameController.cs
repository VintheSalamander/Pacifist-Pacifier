using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject babyZone;
    public static GameController instance;
    private static int activatedZones;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        activatedZones = 0;
        babyZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatedZone(){
        activatedZones += 1;
        if(activatedZones == 7){
            babyZone.SetActive(true);
        }
    }
}
