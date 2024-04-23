using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteNumber : MonoBehaviour
{
    
    public KeyCode keyToPress;
    private bool canBePressed;
    private bool wasPressed;
    private bool oneTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canBePressed){
            if(Input.GetKeyDown(keyToPress)){
                wasPressed = true;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Activator")){
            canBePressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll){
        if(coll.CompareTag("Activator") && !wasPressed && !oneTrigger){
            oneTrigger = true;
            canBePressed = false;
            AudioController.instance.StopMusic();
        }
    }
}
