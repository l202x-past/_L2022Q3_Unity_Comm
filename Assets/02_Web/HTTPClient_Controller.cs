using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class HTTPClient_Controller : MonoBehaviour
{
    string ServerAddr;
    string Mode;
    string Id;
    string Name;
    string Phone;
    string Email;
    //string Request;

    void Start()
    {
        ServerAddr = "http://studio1030.iptime.org:22080/joosun/http_response.php?";
        Mode = "select";
        Name = "Tom";
        Phone = "010-1111-2222";
        Email = "someone@somewhere.com";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string Request = MakeRequest();
            print(Request);
            SendHTTPRequest();
        }
    }

    public void SendHTTPRequest()
    {
        string Request = MakeRequest();
        StartCoroutine(GetRequest(Request));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public void SetMode(string _Mode)
    {
        Mode = _Mode;
    }

    public void SetId(string _Id)
    {
        Id = _Id;
    }

    public void SetName(string _Name)
    {
        Name = _Name;
    }

    public void SetPhone(string _Phone)
    {
        Phone = _Phone;
    }

    public void SetEmail(string _Email)
    {
        Email = _Email;
    }

    public string MakeRequest()
    {
        string Request = ServerAddr + "mode=" + Mode + "&id=" + Id + "&name=" + Name + "&phone=" + Phone + "&email=" + Email;
        return Request;
    }
}
