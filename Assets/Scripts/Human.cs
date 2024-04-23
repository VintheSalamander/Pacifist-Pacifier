using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class Human : MonoBehaviour
{
    public CinemachineFreeLook selfCamera;
    public GameObject pacifierToSpawn;
    public GameObject pacifierInMouth;
    public string correctZoneName;
    public AudioSource selfMusic;
    public AudioSource selfAudio;
    public GameObject canBeConObject;
    private ThirdPersonController selfController;
    private AudioListener selfListener;
    private bool canBeControlled;
    private bool isCorrectPos;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Awake()
    {
        canBeConObject.SetActive(false);
        isCorrectPos = false;
        canBeControlled = true;

        selfCamera.enabled = false;

        selfController = GetComponent<ThirdPersonController>();
        selfController.enabled = false;

        selfListener = GetComponent<AudioListener>();
        selfListener.enabled = false;

        pacifierInMouth.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(selfController.enabled == true){
                DeactivateHuman(5f);;
            }
        }
    }

    void OnTriggerStay(Collider coll){
        if(Input.GetKeyDown(KeyCode.E) && AudioController.instance.controllingHuman == this){
            if(coll.gameObject.name == correctZoneName){
                isCorrectPos = true;
                canBeControlled = false;
                GameController.instance.ActivatedZone();
                AudioController.instance.StopMusic();
                if(gameObject.name == "MomBaby"){
                    Debug.Log("hello");
                    Debug.Log(gameObject.name);
                    AudioController.instance.StopBabyCry();
                }
            }

            
        }
    }

    public void ActivateHuman(){
        pacifierInMouth.SetActive(true);
        selfCamera.enabled = true;
        selfController.enabled = true;
        AudioController.instance.SetHuman(this);
        AudioController.instance.StartMusic();
        selfListener.enabled = true;
        initialPos = transform.position;
    }

    public void DeactivateHuman(float forwardPos){
        if(!isCorrectPos){
            transform.position = initialPos;
            canBeControlled = false;
            StartCoroutine(CanBeControlledAfterDelay(30f));
        }

        selfListener.enabled = false;

        if(selfAudio){
            selfAudio.Stop();
        }

        pacifierInMouth.SetActive(false);

        Vector3 spawnPosition = transform.position + transform.forward * forwardPos;
        spawnPosition.y = 0.827f;
        Instantiate(pacifierToSpawn, spawnPosition, Quaternion.identity);

        selfCamera.enabled = false;
        selfController.enabled = false;
        AudioController.instance.SetHuman(null);
    }

    public bool GetControlBool(){
        return canBeControlled;
    }

    public AudioSource GetMusic(){
        return selfMusic;
    }

    IEnumerator CanBeControlledAfterDelay(float delay)
    {
        canBeConObject.SetActive(true);
        yield return new WaitForSeconds(delay);

        canBeConObject.SetActive(false);
        canBeControlled = true;
    }
}
