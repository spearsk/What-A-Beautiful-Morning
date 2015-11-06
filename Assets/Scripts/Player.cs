using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class Player : MonoBehaviour {
    public static bool test = false;
    bool isNear = false;
    bool isOnQuest = false;
    bool questComplete = false;
    bool questTurnedIn = false;
	public bool showNewPlayerHelp = true;
	public bool showPlayerClickOnCarium = false;
    string listOfCurrentQuests = "";
    public ArrayList currentQuests = new ArrayList();
    public ArrayList completedQuests = new ArrayList();
    public ArrayList questsToTurnIn = new ArrayList();
	public int stopShowing = 0;
	int numberCollected = 0;
	ArrayList pickedUp = new ArrayList();
    public GameObject lightSpace;

    private string collected;
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
        Light lt = lightSpace.GetComponent<Light>();

        GUI.skin.box.wordWrap = true;

		if(showNewPlayerHelp)
		{
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Walk forward and speak to Carium to begin your adventure.");
		}
		
		if(showPlayerClickOnCarium && stopShowing < 2)
		{
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 25), "Click on Carium to interact!");
		}
		
        if (showGUIPickup == true)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Take (T)");
        }

        if (isOnThisQuest("Spare Parts"))
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 50), "Number of parts collected: " + numberCollected.ToString());
        }

        if (questComplete)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 50), "Quest completed!");
        }
        if (lt.intensity > 0)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go home and get some rest.");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
			try{
				if(!pickedUp.Contains(itemToDestroy.name))
				{
					pickedUp.Add(itemToDestroy.name);
					numberCollected++;
					itemCollected();
			
					if (numberCollected == 4)
					{
						questCompleted("Spare Parts");
					}
				}
			}
			catch (Exception e)
			{
			}
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "DoorCollider")
        {
            Light lt = lightSpace.GetComponent<Light>();
            lt.intensity = 0;
            Behaviour halo = (Behaviour)lt.GetComponent("Halo");
            halo.enabled = true;
        }
		if(col.gameObject.name == "CariumInteractBox")
		{
			Debug.Log("Player is in the interact box.");
			showNewPlayerHelp = false;
			showPlayerClickOnCarium = true;
			stopShowing++;
		}
        if (col.gameObject.name == "BoltM6(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
        if (col.gameObject.name == "BoltM6Bit(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
		}
        if (col.gameObject.name == "NutM6(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
        if (col.gameObject.name == "NutM62(Clone)")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = col.gameObject;
            showGUIPickup = true;
        }
    }

    void itemCollected()
    {
        Destroy(itemToDestroy);
        showGUIPickup = false;
    }
}
