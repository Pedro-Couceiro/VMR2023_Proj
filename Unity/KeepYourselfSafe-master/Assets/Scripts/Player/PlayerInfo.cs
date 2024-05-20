using UnityEngine;
using System;

public class PlayerInfo
{
    public PlayerData playerData = new PlayerData();

    [Serializable]
    public class PlayerData
    {
        public PlayerDataValues[] playerDataValues;
    }

    [SerializeField]
    public class PlayerDataValues
    {
        public int PlayerID = 0;
        public string player_name = "";
        public int player_deaths = 0;
    }

    public PlayerData CreateFromJson(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public string createJsonFromObject()
    {
        return JsonUtility.ToJson(playerData);
    }
}
