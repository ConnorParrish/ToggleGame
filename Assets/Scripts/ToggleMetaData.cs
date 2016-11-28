using UnityEngine;
using System.Collections;

[System.Serializable]
public class ToggleMetaData
{


    // put public variables here
    //Public variables should automatically be serializable.
    //private string currentLevel;
    //public int coinsCollected;
    public int coins0_0;
    public int coins1_1;
    public int coins1_2;
    public int coins1_3;
    public int coins1_4;
    public int coins2_2;
    public int coins2_3;
    public int coins2_4;
    public int coins3_1;
    public int noOfDeath;
    bool deathFlag = false;



    // Use this for initialization
    void Start()
    {
        Debug.Log("Created TMD");
    }

    // Update is called once per frame
    void Update() { }



    public void newGame()
    {
        coins0_0 = 0;
        coins1_1 = 0;
        coins1_2 = 0;
        coins1_3 = 0;
        coins1_4 = 0;
        coins2_2 = 0;
        coins2_3 = 0;
        coins2_4 = 0;
        coins3_1 = 0;
        //Set all variables here to 0 or some equivalent
    }

    public void died()
    {
        //if (!deathFlag)
        //{
        //    deathFlag = !deathFlag;
        //    return;
        //}
        //deathFlag = !deathFlag;

        noOfDeath++;
        Debug.Log(noOfDeath);
    }

    public void addCoin()
    {
        switch (SaveScript.currentLevel)
        {
            case ("Level 0-0"):
                //Debug.Log("Working");
                coins0_0++;
                break;
            case ("Level 1-1"):
                Debug.Log("Working 1-1");
                coins1_1++;
                break;
            case ("Level 1-2"):
                coins1_2++;
                Debug.Log("Working 1-2");
                break;
            case ("Level 1-3"):
                //Debug.Log("Working");
                coins1_3++;
                break;
            case ("Level 1-4"):
                //Debug.Log("Working");
                coins1_4++;
                break;
            case ("Level 2-2"):
                //Debug.Log("Working");
                coins2_2++;
                break;
            case ("Level 2-3"):
                //Debug.Log("Working");
                coins2_3++;
                break;
            case ("Level 2-4"):
                //Debug.Log("Working");
                coins2_4++;
                break;
            case ("Level 3-1"):
                //Debug.Log("Working");
                coins3_1++;
                break;
            default:
                //Debug.Log("Default Case");
                break;
        }
    }
}
