using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    public float beatTempo;
    public float multiplier;
    public GameObject[] noteObjects;
    private GameObject closestChild;
    private bool hasStarted;
    private bool generating;
    // Start is called before the first frame update
    void Awake()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted){
            foreach (Transform child in transform){
                child.position -= new Vector3(beatTempo * Time.deltaTime * multiplier, 0f, 0f);
            }
            if(closestChild.GetComponent<RectTransform>().localPosition.x <= -90f && !generating){
                generating = true;
                int randomIndex = Random.Range(0, noteObjects.Length);
                GameObject randomObject = noteObjects[randomIndex];
                closestChild = Instantiate(randomObject, transform);
                generating = false;
            }
        }
    }

    public void StartScroll(){
        int randomIndex = Random.Range(0, noteObjects.Length);
        GameObject randomObject = noteObjects[randomIndex];
        closestChild = Instantiate(randomObject, transform);

        hasStarted = true;
    }

    public void StopScroll(){
        hasStarted = false;
        foreach (Transform child in transform){
            Destroy(child.gameObject);
        }
    }
}
