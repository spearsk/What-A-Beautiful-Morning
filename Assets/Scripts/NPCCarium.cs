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
            dialogue = "Hello Player! How are you doing? I must ask a favour of you. I have 4 spare parts that are scattered around the city " +
                       "please pick them up and bring them back to me!";
            TaskToGive = "Spare Parts";
        }
        else if (player.TasksToTurnIn.Contains("Spare Parts") && Player.hasDoneTask1 == false)
        {
            dialogue = "Ah! You have found all four parts, thank you very much! You should go to your house to get some rest, I will have more for you to do tomorrow";
        }
        else if (Player.hasDoneTask1 == true && !Player.hasSlept)
        {
            dialogue = "I have no further favours to ask you. Go home and get some rest and I will have something for you tomorrow.";
            TaskToGive = "";
        }
        else if( Player.hasSlept)
        {
            dialogue = "I'm not quite sure what has happened here! There was a strange blinding light and BAM! the buildings began to collapse around me, i ran as fast as i could as far as i could! I'm glad you survived as well! Why don't you go look around the city to see what you can find out.";
            TaskToGive = "Find The Culprit";
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
            else if (TaskToGive == "")
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Goodbye"))
                {
                    talk = false;
                    player.notOnTask();
                    Light lt = lightSpace.GetComponent<Light>();
                    lt.intensity = 6;
                }
            }
            else if (Player.hasDoneTask1 == true && Player.hasDoneTask2 == false)
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
                    if (TaskToGive == "Find The Culprit")
                    {
                        sd.SpawnIt();
                    }
                }
            }
            else if(Player.hasDoneTask1 == false)
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
        }
    }
}
