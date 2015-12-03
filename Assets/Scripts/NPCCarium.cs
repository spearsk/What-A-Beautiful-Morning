using UnityEngine;
using System.Collections;

public class NPCCarium : MonoBehaviour {
    string innerText = null;
    string dialogue = null;
    bool isClose = false;
    bool talk = false;
    bool highlighted = false;
    Vector2 scrollViewVector = Vector2.zero;
    int textLength = 335;
    public Player player;
    public CariumWaypoint cw;
    public SpawnParts sp;
    public SpawnDestroyer sd;
    string TaskToGive = "";
    public GameObject lightSpace;
    bool displayThis = false;
    public int carPos = 0;

    int page = 0;

    void OnMouseOver()
    {
        GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 1.5f);
        Debug.Log("Player is hovering over Kyle");
        highlighted = true;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
        highlighted = false;
        Debug.Log("Player is not hovering over Kyle now.");
    }

    void Start()
    {
        lightSpace.AddComponent<Light>();
        Light lt = lightSpace.GetComponent<Light>();
        lt.intensity = 0;
    }   
    void Update()
    {
        if (player.isOnThisTask("Spare Parts") == false && player.TasksToTurnIn.Contains("Spare Parts") == false && Player.hasDoneTask1 == false)
        {
            dialogue = "Ah, hello sir! Done with work today already? I didn't realize it was already closing time! Say, could you do me a favor? I've lost a few parts of mine, four to be precise. " +
                       "Could you please pick them up and bring them back to me?";
            TaskToGive = "Spare Parts";
        }
        else if (player.TasksToTurnIn.Contains("Spare Parts") && Player.hasDoneTask1 == false)
        {
            dialogue = "Ah! You have found all four parts, thank you very much! You should go to your house to get some rest; you have a busy day tomorrow!";
        }
        else if (Player.hasDoneTask1 == true && !Player.hasSlept)
        {
            dialogue = "I have no further favours to ask you. Go home and get some rest and I will have something for you tomorrow.";
            TaskToGive = "";
        }
        else if( Player.hasSlept && page == 0)
        {
            dialogue = "Good morning, sir! Are you feeling well? You seem a bit distraught! Perhaps a bad dream visited you last night?";
        }
        else if (Player.hasSlept && page == 1 && carPos == 0)
        {
            dialogue = "The buildings are destroyed? I'm sure I don't know what you mean, sir. You'd best get to work soon; that'll get your mind off this whole affair! Your boss must be looking for you.";
            TaskToGive = "Find The Culprit";
        }
            // carium has moved to new position
        else if (!player.TasksToTurnIn.Contains("Spare Parts 2") && carPos == 1)
        {
            dialogue = "Hello again sir! I'm so sorry for how clumsy I am, but I seem to have dropped those parts yet again. " +
                "Could you perhaps fetch them for me again?";
            TaskToGive = "Spare Parts 2";
        }
        else if (player.TasksToTurnIn.Contains("Spare Parts 2"))
        {
            dialogue = "Ah! You have found all four parts, thank you very much! Why don't you take the day off? I'm sure your boss won't mind!";
        }
        if (cw.isTrue())
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }
    }
    void OnGUI()
    {
        GUI.skin.button.wordWrap = true;

        Event click = Event.current;
        if (click.button == 0 && click.isMouse)
        {
            if (highlighted == true)
            {
                talk = true;
				Player.showPlayerClickOnCarium = false;
            }
        }

        if (talk && isClose)
        {

            GUI.Box(new Rect(50, 50, 325, 400), "Carium");

            // Begin the ScrollView
            scrollViewVector = GUI.BeginScrollView(new Rect(60, 75, 310, 345), scrollViewVector, new Rect(0, 0, 90, textLength + 10));

            // Put something inside the ScrollView
            innerText = GUI.TextArea(new Rect(5, 5, 287, textLength), dialogue);

            // End the ScrollView
            GUI.EndScrollView();
            // Close button
            //if (GUI.Button(new Rect(350, 53, 22, 15), "x"))
            //{
            //////Debug.Log("Closed the dialogue box.");
            //    talk = false;
            //}
            if (player.TasksToTurnIn.Contains("Spare Parts"))
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Turn In"))
                {
                    talk = false;
                    player.TaskTurnIn("Spare Parts");
                    Player.hasDoneTask1 = true;
                    player.numberCollected = 0;

                    Light lt = lightSpace.GetComponent<Light>();
                    lt.intensity = 8;
                }
            }
            else if (player.TasksToTurnIn.Contains("Find The Culprit"))
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Turn In"))
                {
                    talk = false;
                    player.TaskTurnIn("Find The Culprit");
                    Player.hasDoneTask2 = true;
                }
            }
            else if (TaskToGive == "" && !Player.hasSlept)
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Goodbye"))
                {
                    talk = false;
                    player.notOnTask();
                    Light lt = lightSpace.GetComponent<Light>();
                    lt.intensity = 6;
                }
            }
            else if (TaskToGive == "" && Player.hasSlept && page == 0 && carPos == 0)
            {
                if (GUI.Button(new Rect(287, 425, 84, 20), "Buildings?"))
                {
                    page = 1;
                }
            }
            else if (Player.hasDoneTask1 == true && Player.hasDoneTask2 == false && carPos == 0)
            {
                Debug.Log("Find the culprit");
                //(h-position, v-position, h-size, v-size)
                if (GUI.Button(new Rect(307, 425, 64, 20), "Decline"))
                {
                    talk = false;
                    player.notOnTask();
                }

                if (GUI.Button(new Rect(207, 425, 64, 20), "Accept"))
                {
                    talk = false;
                    player.goOnTask(TaskToGive);
                    Player.showPlayerClickOnCarium = false;
                    if (TaskToGive == "Find The Culprit")
                    {
                        sd.SpawnIt();
                    }
                }
            }
            else if(Player.hasDoneTask1 == false && carPos == 0)
            {
                Debug.Log("Spare Parts 1");
                //(h-position, v-position, h-size, v-size)
                if (GUI.Button(new Rect(307, 425, 64, 20), "Decline"))
                {
                    talk = false;
                    player.notOnTask();
                }

                if (GUI.Button(new Rect(207, 425, 64, 20), "Accept"))
                {
                    talk = false;
                    player.goOnTask(TaskToGive);
                    Player.showPlayerClickOnCarium = false;
                    if (TaskToGive == "Spare Parts")
                    {
                        sp.SpawnAllParts();
                    }
                }
            }
            else if (player.TasksToTurnIn.Contains("Spare Parts 2"))
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Goodbye"))
                {
                    player.TaskTurnIn("Spare Parts 2");
                    talk = false;
                    player.notOnTask();
                    Light lt = lightSpace.GetComponent<Light>();
                    lt.intensity = 6;
                }
            }
            else if (Player.hasDoneTask1 == true && Player.hasDoneTask2 == true && carPos == 1 && !player.currentTasks.Contains("Spare Parts 2")
                && !player.completedTasks.Contains("Spare Parts 2"))
            {
                Debug.Log("Spare Parts 2");
                //(h-position, v-position, h-size, v-size)
                if (GUI.Button(new Rect(307, 425, 64, 20), "Decline"))
                {
                    talk = false;
                    player.notOnTask();
                }

                if (GUI.Button(new Rect(207, 425, 64, 20), "Accept"))
                {
                    talk = false;
                    player.goOnTask(TaskToGive);
                    Player.showPlayerClickOnCarium = false;
                    if (TaskToGive == "Spare Parts 2")
                    {
                        sp.SpawnAllParts();
                    }
                }
            }
        }
    }
}
