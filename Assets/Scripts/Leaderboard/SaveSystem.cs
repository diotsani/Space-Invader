using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;

    [SerializeField]
    public List<PlayerData> userList = new List<PlayerData> ();

    private string persistentPath = "";


    public void CreatePlayerData(string username, int score)
    {
        playerData.add(username, score);
        userList.Add(playerData);
    }

    void SetPath()
    {
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    private void Start()
    {
        SetPath();

    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(userList);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(persistentPath);

        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(userList.Count);
            Debug.Log(userList[0]);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            
        }
    }

}
