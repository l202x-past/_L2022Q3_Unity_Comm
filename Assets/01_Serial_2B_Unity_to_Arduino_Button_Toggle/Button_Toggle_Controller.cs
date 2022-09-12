using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Toggle_Controller : MonoBehaviour
{
    int value = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleButton(GameObject SerialController)
    {
        value = 1 - value;
        if(value == 0) // led off
        {
            gameObject.GetComponent<Image>().color = Color.gray;
        }
        else if(value == 1)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        string serialOut = value.ToString();
        SerialController.GetComponent<Serial_SimpleWrite_Toggle>().SimpleWrite(serialOut);
    }
}
