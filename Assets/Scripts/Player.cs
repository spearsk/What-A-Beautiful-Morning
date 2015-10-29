using UnityEngine;
using System.Collections;
using System.Text;

public class Player : MonoBehaviour {
    public bool isNear = false;
    public bool isOnQuest = false;
    public bool questComplete = false;
    public bool questTurnedIn = false;
    string listOfCurrentQuests = "";
    public ArrayList currentQuests = new ArrayList();
    public ArrayList completedQuests = new ArrayList();

    // Use this for initialization
    void Start () {
        foreach (string value in currentQuests)
        {
            Debug.Log(value);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isNowNear()
    {
        return isNear = true;
    }
    public bool isNotNear()
    {
        return isNear = false;
    }

    public bool goOnQuest(string quest)
    {
        currentQuests.Add(quest);

        foreach (string value in currentQuests)
        {
            Debug.Log(value);
        }
        return isOnQuest = true;
    }

    public bool notOnQuest()
    {
        return isOnQuest = false;
    }

    public bool questCompleted()
    {
        return questComplete = true;
    }

    public void questTurnIn(string quest)
    {
        completedQuests.Add(quest);
    }

    public void CurrentQuestsList()
    {
        StringBuilder sb = new StringBuilder();
        foreach ( string quest in completedQuests)
        {
            sb.Append(quest);
        }

       listOfCurrentQuests = sb.ToString();
    }

    public bool isOnThisQuest(string quest)
    {
        if (currentQuests.Contains(quest))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnGUI()
    {
        GUI.skin.box.wordWrap = true;
        if (questComplete == true)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 100), "Quest completed!");
        }

        if(isOnQuest)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 100), listOfCurrentQuests);
        }
    }
}
