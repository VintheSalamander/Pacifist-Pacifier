using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicButtonController : MonoBehaviour
{
    
    public Color pressedColor;
    public Color nonPressedColor;
    private Image image;
    private KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Alpha4)){
            image.color = pressedColor;
        }

        if(Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3) ||
            Input.GetKeyUp(KeyCode.Alpha4)){
            image.color = nonPressedColor;
        }
    }
}
