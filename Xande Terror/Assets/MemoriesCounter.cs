using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoriesCounter : MonoBehaviour
{
    public static MemoriesCounter Instance;
    public TextMeshProUGUI memoriesCounter;
    public static int memoriesCount;

    public bool[] whatScene = new bool[3];

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        memoriesCounter.text = "Balloons Collected: " + memoriesCount.ToString() + "/8";

            if(memoriesCount == 8)
            {
                SceneManager.LoadScene("MenuScene");

            }
        
    }
    public void Start()
    {
        memoriesCount = 0;
    }
}
