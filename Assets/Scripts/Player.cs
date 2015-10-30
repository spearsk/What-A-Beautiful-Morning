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
    public ArrayList questsToTurnIn = new ArrayList();

    private string collected;
    int numCollected = 0;
    private bool showGUIPickup = false;
    private GameObject itemToDestroy;

    // Use this for initialization
    void Start () {
        foreach (string value in currentQuests)
        {
            //Debug.Log(value);
        }
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
            //Debug.Log(value);
        }
        return isOnQuest = true;
    }

    public bool notOnQuest()
    {
        return isOnQuest = false;
    }

    public bool questCompleted(string quest)
    {
        currentQuests.Remove(quest);
        questsToTurnIn.Add(quest);
        return questComplete = true;
    }

    public void questTurnIn(string quest)
    {
        questsToTurnIn.Remove(quest);
        completedQuests.Add(quest);
        notOnQuest();
        questComplete = false;
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

    public bool hasDoneQuest(string quest)
    {
        if (completedQuests.Contains(quest))
         {
            return true;
         }
        else
        {
            return false;
        }
    }

    public bool isReadyToTurnIn(string quest)
    {
        if (questComplete && !questTurnedIn)
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

        if (showGUIPickup == true)
        {
            GUI.Label(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 100), "Take (T)");

        }

        if (isOnThisQuest("Spare Parts"))
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 100), "Number of parts collected: " + numCollected.ToString());
        }

        if (questComplete)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 100), "Quest completed!");
        }

        if(isOnQuest)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 100), listOfCurrentQuests);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            itemCollected();
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "BoltM6(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
        if (col.gameObject.tag == "BoltM6Bit(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
        if (col.gameObject.tag == "NutM6(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
        if (col.gameObject.tag == "NutM62(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
    }

    void itemCollected()
    {
        numCollected++;
        Destroy(itemToDestroy);

        if (numCollected == 4)
        {
            questCompleted("Spare Parts");
        }

        showGUIPickup = false;
    }
}
