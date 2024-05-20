using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private HttpRequest webRequest;

    private PlayerInfo _playerInfo;

    public PlayerInfo PlayerInfo 
    { 
        get => _playerInfo; 
        
        set => _playerInfo = value; 
    }

    void Start()
    {
        _playerInfo = new PlayerInfo();

        webRequest.OnGetRequest("/get-player-data");
    }
}
