using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int pigsInLevel;
    [SerializeField] int birdsInLevel;
    [SerializeField] GameObject pigPrefab;
    [SerializeField] LaunchManager launchManager;

    private int currentPigCount;
    private int currentBirdCount;

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
    void Update()
    {
        // check for touch input
        if(Input.touchCount == 1 && !launchManager.ObjectPlaced)
        {
            //place object on plane if not already done
        }
        if(Input.touchCount > 1 && launchManager.ObjectPlaced)
        {
            // multi-touch - launch object if placed
        }
    }

    private void CreateAPig()
    {
        // Get a random start position

        // instantiate the pig

        // fly the pig

        Debug.Log ("Pretend that pigs can fly");
    }

    public void OnDied(GameObject deadObject)
    {
        if(deadObject.GetComponent<ILaunchable>() != null)
        {
            // bird is dead
            currentBirdCount--;
            if (currentBirdCount == 0)
            {
                LoseGame();
            }
        }

        if (deadObject.GetComponent<IFlyingTarget>() != null)
        {
            // pig is dead
            currentPigCount--;
            if (currentPigCount == 0)
            {
                WinGame();
            }
        }
    }

    public void LoseGame()
    {
        // change UI to lose game message
    }

    public void WinGame()
    {
        // change UI to win game message
    }
    
}
