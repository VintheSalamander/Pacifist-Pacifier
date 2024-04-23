using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class Pacifier : MonoBehaviour
{
    public CinemachineFreeLook selfCamera;
    private GameObject firstHuman;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("Human") && coll.GetComponent<Human>().GetControlBool()){
            if(firstHuman == null){
                firstHuman = coll.gameObject;
            }
        }
    }

    void OnTriggerStay(Collider coll){
        if(coll.CompareTag("Human") && coll.GetComponent<Human>().GetControlBool()){
            if(firstHuman == null){
                firstHuman = coll.gameObject;
            }
        }

        if(Input.GetKeyDown(KeyCode.E)){
            
            if(firstHuman){
                Debug.Log(firstHuman.name);
                if(coll.gameObject == firstHuman){
                    Debug.Log(coll.gameObject.name);
                    coll.GetComponent<Human>().ActivateHuman();
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.CompareTag("Human")){
            if(firstHuman == coll.gameObject){
                firstHuman = null;
            }
        }
    }
}
