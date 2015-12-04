using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class Player : MonoBehaviour {
    public static bool test = false;
    bool isNear = false;
    bool isOnTask = false;
    bool TaskComplete = false;
    bool TaskTurnedIn = false;
    string listOfCurrentTasks = "";
    public ArrayList currentTasks = new ArrayList();
    public ArrayList completedTasks = new ArrayList();
    public ArrayList TasksToTurnIn = new ArrayList();
	int stopShowing = 0;
	public int numberCollected = 0;
	ArrayList pickedUp = new ArrayList();
    public GameObject lightSpace;
    private bool showSleepTrigger = false;
    private string collected;
    private bool showGUIPickup = false;
    private GameObject itemToDestroy;
    bool inPostSleepCity = false;

    //Statics
    public static string nextScene = "PreDestructionCity";
    public static bool isInHouse = false;
    public static bool showNewPlayerHelp = true;
    public static bool showPlayerClickOnCarium = false;
    public static bool showPlayerClickOnKyle = false;
    public static bool hasSlept = false;
    public static bool isNearBed = false;
    public static bool isNearDoorInsideHouse = false;
    public static bool showGoOutside = false;
    public static bool hasDoneTask1 = false;
    public static bool hasDoneTask2 = false;
    public static bool hasStartedTask2 = false;
    public FlashStatic flash;

    // Use this for initialization
    void Start () {
    }

    public bool isNowNear()
    {
        return isNear = true;
    }
    public bool isNotNear()
    {
        return isNear = false;
    }

    public bool goOnTask(string Task)
    {
        currentTasks.Add(Task);

        foreach (string value in currentTasks)
        {
            //Debug.Log(value);
        }
        return isOnTask = true;
    }

    public bool notOnTask()
    {
        return isOnTask = false;
    }

    public bool TaskCompleted(string Task)
    {
        currentTasks.Remove(Task);
        TasksToTurnIn.Add(Task);
        return TaskComplete = true;
    }

    public void TaskTurnIn(string Task)
    {
        TasksToTurnIn.Remove(Task);
        completedTasks.Add(Task);
        notOnTask();
        TaskComplete = false;
    }

    public void CurrentTasksList()
    {
        StringBuilder sb = new StringBuilder();
        foreach ( string Task in completedTasks)
        {
            sb.Append(Task);
        }

       listOfCurrentTasks = sb.ToString();
    }

    public bool isOnThisTask(string Task)
    {
        if (currentTasks.Contains(Task))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool hasDoneTask(string Task)
    {
        if (completedTasks.Contains(Task))
         {
            return true;
         }
        else
        {
            return false;
        }
    }

    public bool isReadyToTurnIn(string Task)
    {
        if (TaskComplete && !TaskTurnedIn)
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

		if(showNewPlayerHelp && !isInHouse)
		{
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Walk forward and speak to Carium to begin your adventure.");
		}

        if (showPlayerClickOnCarium && isNear && Player.hasDoneTask1 == false)
		{
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 25), "Click on Carium to interact!");
		}
		
        if (showGUIPickup == true)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Take (T)");
        }

        if (isOnThisTask("Spare Parts"))
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 50), "Number of parts collected: " + numberCollected.ToString());
        }

        if (isOnThisTask("Spare Parts 2"))
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 50), "Number of parts collected: " + numberCollected.ToString());
        }

        if (TaskComplete)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 50), "Task completed!");
        }
        if (lt.intensity > 0)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go home and get some rest.");
        }
        if (showSleepTrigger)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Sleep (E)");
        }

        if (hasSlept && isInHouse)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go outside and speak to Carium.");
        }

        if (!hasSlept && isInHouse)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go to your Futon to get some sleep.");
        }

        if (showGoOutside)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Go outside (E)");
        }

        if (hasSlept && !isInHouse && !isOnThisTask("Find The Culprit"))
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go seek out Carium to find out what happened.");
        }
        if (isOnThisTask("Find The Culprit") && Player.hasDoneTask2 == false)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Look around the city and find who...or what did this.");
        }
    }
    void Update()
    {
        if (currentTasks.Contains("Spare Parts") && Input.GetKeyDown(KeyCode.T))
        {
			try{
				if(!pickedUp.Contains(itemToDestroy.name))
				{
					pickedUp.Add(itemToDestroy.name);
					numberCollected++;
					itemCollected();
			
					if (numberCollected == 4)
					{
						TaskCompleted("Spare Parts");
					}
				}
			}
			catch (Exception e)
			{
			}
        }
        if (currentTasks.Contains("Spare Parts 2") && Input.GetKeyDown(KeyCode.T))
        {
            try
            {
                if (!pickedUp.Contains(itemToDestroy.name))
                {
                    pickedUp.Add(itemToDestroy.name);
                    numberCollected++;
                    itemCollected();

                    if (numberCollected == 4)
                    {
                        TaskCompleted("Spare Parts 2");
                        //StartCoroutine(BackToPresent());
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && !hasSlept && isNearBed)
        {
            Application.LoadLevel("SleepScene");
        }
        if (Input.GetKeyDown(KeyCode.E) && hasSlept && isInHouse)
        {
            inPostSleepCity = true;
            nextScene = "PostDestructionCity";
            showGoOutside = false;
            isInHouse = false;
            Application.LoadLevel("LoadingScreen");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "DoorCollider")
        {
            Light lt = lightSpace.GetComponent<Light>();
            lt.intensity = 0;
        }
		if(col.gameObject.name == "CariumInteractBox")
		{
			Debug.Log("Player is in the interact box.");
			showNewPlayerHelp = false;
			showPlayerClickOnCarium = true;
			stopShowing++;
		}
        if (col.gameObject.name == "RobotKyleCollider")
        {
            Debug.Log("Player is in the interact box.");
            showPlayerClickOnKyle = true;
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
        if (col.gameObject.name == "Futon" && !hasSlept)
        {
            showSleepTrigger = true;
            isNearBed = true;
        }
        if (col.gameObject.name == "Door Collider" && hasSlept)
        {
            showGoOutside = true;
            isNearDoorInsideHouse = true;
        }
    }

    void itemCollected()
    {
        Destroy(itemToDestroy);
        showGUIPickup = false;
    }

    IEnumerator BackToPresent()
    {
        flash.showImage = true;
        Vector3 currentPos = new Vector3();
        currentPos = transform.position;
        Application.LoadLevel("PreDestructionCity");
        yield return new WaitForSeconds(.25f);
        flash.showImage = false;
    }
}
