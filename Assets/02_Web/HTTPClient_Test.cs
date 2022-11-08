using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPClient_Test : MonoBehaviour
{    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("request");
            StartCoroutine(SendRequest());
        }
    }

    IEnumerator SendRequest()
    {
        string key1 = "myVar";
        string val1 = "hello";

        string key2 = "myVar1";
        string val2 = "hihihi";

        string request = "http://studio1030.iptime.org:22080/joosun/http_response.php?"+key1+"="+val1+"&"+key2+"="+val2;
        print("url=" + request);
        UnityWebRequest webRequest = UnityWebRequest.Get(request);

        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            print(webRequest.downloadHandler.text);
        }
        else
        {
            print(webRequest.result);
        }
        print("end of request");
    }
}
