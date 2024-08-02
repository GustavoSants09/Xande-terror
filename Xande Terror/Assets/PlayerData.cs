using UnityEngine;

public class PlayerData
{
    int life;
    int levelID;

    Transform playerPos;
    bool milkGot;

    public void RegisterValues(int life, int levelID)
    {
        this.life = life;
        this.levelID = levelID;
    }

    public int GetLife()
    {
        return life;
    }
    public int LevelID()
    {
        return levelID;
    }
}

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    PlayerData playerData;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        playerData = new PlayerData();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerData.RegisterValues(3, 1);
            Save();
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            Load();
        }
        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            Reset();
        }
    }
    public void Save()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        string data = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText(filePath, data);

        print(filePath);
    }
    public void Load()
    {
        string filePath = Application.persistentDataPath + "PlayerData.json";
        if(System.IO.File.Exists(filePath))
        {
            string data = System.IO.File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(data);
        }
    }
    public void Reset()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            playerData = new PlayerData();
        }
    }
}
