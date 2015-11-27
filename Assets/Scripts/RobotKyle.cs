using UnityEngine;
using System.Collections;

public class RobotKyle : MonoBehaviour {
    string innerText = null;
    string dialogue = null;
    bool isClose = false;
    bool talk = false;
    bool highlighted = false;
    Vector2 scrollViewVector = Vector2.zero;
    int textLength = 335;
    public RobotKyleWaypoint ckw;
    public Player player;
    string TaskToGive = "";


    void OnMouseOver()
    {
        GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 1.5f);
        highlighted = true;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
        highlighted = false;
    }

    void Update()
    {
            if (player.isOnThisTask("Spare Parts") == false && player.TasksToTurnIn.Contains("Spare Parts") == false && Player.hasDoneTask1 == false)
            {
                dialogue = "Hello Player! How are you doing? I must ask a favour of you. I have 4 spare parts that are scattered around the city " +
                           "please pick them up and bring them back to me!";
                TaskToGive = "Spare Parts";
            }
            if (ckw.isTrue())
            {
                isClose = true;
            }
            else
            {
                isClose = false;
            }
        }
    

    // Use this for initialization
    void Start () {
	
	}

    void OnGUI()
    {
        GUI.skin.button.wordWrap = true;

        Event click = Event.current;
        if (click.button == 0 && click.isMouse)
        {
            Debug.Log("Player has Clicked");
            if (highlighted == true)
            {
                Debug.Log("Player should be talking to robot");
                talk = true;
                Player.showPlayerClickOnKyle = false;
            }
        }

        if (talk && isClose)
        {

            GUI.Box(new Rect(50, 50, 325, 400), "Robot Kyle");

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
            if (player.TasksToTurnIn.Contains("Find The Culprit"))
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Turn In"))
                {
                    talk = false;
                    player.TaskTurnIn("Find The Culprit");
                    Player.hasDoneTask2 = true;
                }
            }
            /*
            else if (Player.hasDoneTask1 == false)
            {
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
            */

        }
    }
}
