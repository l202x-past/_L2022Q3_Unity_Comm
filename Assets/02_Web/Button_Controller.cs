using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour
{
    HTTPClient_Controller Client;
    
    void Start()
    {
        //Client = GameObject.Find("HTTPClient_Controller").GetComponent<HTTPClient_Controller>();
        Client = FindObjectOfType<HTTPClient_Controller>();
    }

    public void OnClick_Test()
    {
        //string result = Client.MakeRequest();
        //print(result);
        string Mode = GameObject.Find("Dropdown_Mode").GetComponent<Dropdown>().value.ToString();
        string Id = GameObject.Find("InputField_Id").GetComponent<InputField>().text;
        string Name = GameObject.Find("InputField_Name").GetComponent<InputField>().text;
        string Phone = GameObject.Find("InputField_Phone").GetComponent<InputField>().text;
        string Email = GameObject.Find("InputField_Email").GetComponent<InputField>().text;
        Client.SetMode(Mode);
        Client.SetId(Id);
        Client.SetName(Name);
        Client.SetPhone(Phone);
        Client.SetEmail(Email);
        Client.SendHTTPRequest();
    }
}
