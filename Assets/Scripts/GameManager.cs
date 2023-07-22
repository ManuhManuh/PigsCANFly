using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int pigsInLevel;
    [SerializeField] int birdsInLevel;
    [SerializeField] GameObject pigPrefab;
    [SerializeField] LaunchManager launchManager;
    [SerializeField] float startPositionBoxSize;    // remove if point cloud used instead of Random.Range
    [SerializeField] TMP_Text message;

    public static GameManager instance;

    private int currentPigCount;
    private int currentBirdCount;

    private void Awake()
    {
        // Are there any other game managers yet?
        if (instance != null)
        {
            // Error
            Debug.LogError("There was more than 1 Game Manager");
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    { 
        currentBirdCount = birdsInLevel;
        currentPigCount = pigsInLevel;

        // instantiate flying targets
        for(int i = 1; i <= pigsInLevel; i++)
        {
            CreateAPig();
        }
    }

    // Update is called once per frame

    private void CreateAPig()
    {
        // Get a random start position
        Vector3 startPosition = RandomPosition();

        // instantiate the pig
        GameObject pig = Instantiate(pigPrefab, startPosition, Quaternion.identity);

    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(startPositionBoxSize*-1, startPositionBoxSize);
        float y = Random.Range(startPositionBoxSize*-1, startPositionBoxSize);
        float z = Random.Range(startPositionBoxSize*-1, startPositionBoxSize);

        return new Vector3(x, y, z);
    }

    public void OnDied(GameObject deadObject)
    {
        if(deadObject.GetComponent<ILaunchable>() != null)
        {
            // bird is dead
            currentBirdCount--;
            message.text = "Bird is dead!";
            if (currentBirdCount == 0)
            {
                LoseGame();
            }
            else
            {
                launchManager.ObjectPlaced = false;
            }
        }

        if (deadObject.GetComponent<IFlyingTarget>() != null)
        {
            // pig is dead
            currentPigCount--;
            message.text = "Pig is dead!";
            if (currentPigCount == 0)
            {
                WinGame();
            }
        }
    }

    public void LoseGame()
    {
        // change UI to lose game message
        message.text = "You Lose!!!";
    }

    public void WinGame()
    {
        // change UI to win game message
        message.text = "You Win!!!";
    }
    
}
