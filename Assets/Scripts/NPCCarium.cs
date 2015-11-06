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
    string questToGive = "";
    public GameObject lightSpace;
    bool displayThis = false;

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

    void Start()
    {
        lightSpace.AddComponent<Light>();
        Light lt = lightSpace.GetComponent<Light>();
        lt.intensity = 0;
    }   
    void Update()
    {
        if (player.isOnThisQuest("Spare Parts") == false && player.questsToTurnIn.Contains("Spare Parts") == false && player.hasDoneQuest("Spare Parts") == false)
        {
            dialogue = "Hello Player! How are you doing? I must ask a favour of you. I have 4 spare parts that are scattered around the city " +
                       "please pick them up and bring them back to me!";
            questToGive = "Spare Parts";
        }
        else if (player.questsToTurnIn.Contains("Spare Parts"))
        {
            dialogue = "Ah! You have found all four parts, thank you very much! You should go to your house to get some rest, I will have more for you to do tomorrow";
        }
        else
        {
            dialogue = "I have no further favours to ask you. Go home and get some rest and I will have something for you tomorrow.";
            questToGive = "";
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
				player.showPlayerClickOnCarium = false;
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
            if (player.questsToTurnIn.Contains("Spare Parts"))
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Turn In"))
                {
                    talk = false;
                    player.questTurnIn("Spare Parts");

                    Light lt = lightSpace.GetComponent<Light>();
                    lt.intensity = 8;
                    Behaviour halo = (Behaviour)lt.GetComponent("Halo");
                    halo.enabled = true;
                }
            }
            else if(questToGive == "")
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Goodbye"))
                {
                    talk = false;
                    player.notOnQuest();
                    Light lt = lightSpace.GetComponent<Light>();
                    lt.intensity = 6;
                }
            }
            else
            {
                //(h-position, v-position, h-size, v-size)
                if (GUI.Button(new Rect(307, 425, 64, 20), "Decline"))
                {
                    talk = false;
                    player.notOnQuest();
                }

                if (GUI.Button(new Rect(207, 425, 64, 20), "Accept"))
                {
                    talk = false;
                    player.goOnQuest(questToGive);
                    if (questToGive == "Spare Parts")
                    {
                        sp.SpawnAllParts();
                    }
                }
            }
        }
    }
}
