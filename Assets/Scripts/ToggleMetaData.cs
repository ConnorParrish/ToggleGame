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

    public string prog0_0;
    public string prog1_1;
    public string prog1_2;
    public string prog1_3;
    public string prog1_4;
    public string prog2_2;
    public string prog2_3;
    public string prog2_4;
    public string prog3_1;

    bool deathFlag = false;



    // Use this for initialization
    void Start()
    {
        newGame();
    }

    // Update is called once per frame
    void Update() { }



    public void newGame()
    {
        Debug.Log("New Game Triggered");
        coins0_0 = 0;
        coins1_1 = 0;
        coins1_2 = 0;
        coins1_3 = 0;
        coins1_4 = 0;
        coins2_2 = 0;
        coins2_3 = 0;
        coins2_4 = 0;
        coins3_1 = 0;

        noOfDeath = 0;

        prog0_0 = "0";
        prog1_1 = "0";
        prog1_2 = "0";
        prog1_3 = "0";
        prog1_4 = "0";
        prog2_2 = "0";
        prog2_3 = "0";
        prog2_4 = "0";
        prog3_1 = "0";
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
        //Debug.Log(noOfDeath);
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

    public string progress(string displayLevel)
    {
        switch (displayLevel)
        {
            case ("Level 0-0"):
                return prog0_0;
            case ("Level 1-1"):
                return prog1_1;

            case ("Level 1-2"):
                return prog1_2;

            case ("Level 1-3"):
                return prog1_3;

            case ("Level 1-4"):
                return prog1_4;

            case ("Level 2-2"):
                return prog2_2;

            case ("Level 2-3"):
                return prog2_3;

            case ("Level 2-4"):
                return prog2_4;

            case ("Level 3-1"):
                return prog3_1;

            default:
                return "Error, invalid level";
        }
    }


    public int coinProgress(string displayLevel)
    {
        switch (displayLevel)
        {
            case ("Level 0-0"):
                return coins0_0;
            case ("Level 1-1"):
                return coins1_1;

            case ("Level 1-2"):
                return coins1_2;

            case ("Level 1-3"):
                return coins1_3;

            case ("Level 1-4"):
                return coins1_4;

            case ("Level 2-2"):
                return coins2_2;

            case ("Level 2-3"):
                return coins2_3;

            case ("Level 2-4"):
                return coins2_4;

            case ("Level 3-1"):
                return coins3_1;

            default:
                return 100;
        }
    }

    public void saveProgress(string bestProgress)
    {
        switch (SaveScript.currentLevel)
        {
            case ("Level 0-0"):
                prog0_0 = bestProgress;
                break;
            case ("Level 1-1"):
                prog1_1 = bestProgress;
                break; 
            case ("Level 1-2"):
                prog1_2 = bestProgress;
                break;

            case ("Level 1-3"):
                prog1_3 = bestProgress;
                break;

            case ("Level 1-4"):
                prog1_4 = bestProgress;
                break;

            case ("Level 2-2"):
                prog2_2 = bestProgress;
                break;

            case ("Level 2-3"):
                prog2_3 = bestProgress;
                break;

            case ("Level 2-4"):
                prog2_4 = bestProgress;
                break;

            case ("Level 3-1"):
                prog3_1 = bestProgress;
                break;

            default:
                return;
        }
    }
}
