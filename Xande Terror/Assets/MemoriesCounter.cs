using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoriesCounter : MonoBehaviour
{
    public static MemoriesCounter Instance;
    public TextMeshProUGUI memoriesCounter;
    public int memoriesCount;

    public bool[] whatScene = new bool[3];

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        memoriesCounter.text = "Balloons Collected: " + memoriesCount.ToString() + "/8";

        if (whatScene[0])
        {
            if(memoriesCount == 8)
            {
                SceneManager.LoadScene("MenuScene");

            }
        }
        if (whatScene[1])
        {
            if (memoriesCount == 6)
            {

            }
        }
        if (whatScene[2])
        {
            if (memoriesCount == 12)
            {
                
            }
        }
    }
}
