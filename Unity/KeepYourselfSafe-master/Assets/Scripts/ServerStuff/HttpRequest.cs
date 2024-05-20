using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRequest : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerActions playerActions;

    [Header("Server Data")]
    [SerializeField] private string host;
    [SerializeField] private string port;

    [Header("Server Properties")]
    [SerializeField] private int timeOutTime;

    private string _urlGetPath;

    void Awake()
    {

        _urlGetPath = "http://" + host + ":" + port;
        
    }
     
    public void OnGetRequest(string urlPath)
    {
        StartCoroutine(GetRequest(_urlGetPath + urlPath));
    }

    IEnumerator GetRequest(string urlGetRequest)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(urlGetRequest);

        webRequest.timeout = timeOutTime;

        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log($"{webRequest.error}");
        }
        else
        {
            string ResponseReceived = webRequest.downloadHandler.text;

            playerActions.PlayerInfo.playerData = playerActions.PlayerInfo.CreateFromJson(ResponseReceived);
        }
    }
}
