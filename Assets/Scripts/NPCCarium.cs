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
        dialogue = "Hello Player! How are you doing? I must ask a favor of you. I have 4 spare parts that are scattered around the city " +
                   "please pick them up and bring them back to me!";
    }
    void Update()
    {/*
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance < 20)
        {
            isClose = true;
            Debug.Log("Player is within 4 units of NPC");
        }
        else
        {
            isClose = false;
            Debug.Log("Player is no longer within 4 units of NPC");
        }
        */
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
                //Debug.Log("Closed the dialogue box.");
            //    talk = false;
            //}

            //(h-position, v-position, h-size, v-size)
            if (GUI.Button(new Rect(307, 425, 64, 20), "Decline"))
            {
                talk = false;
                player.notOnQuest();
            }

            if(GUI.Button(new Rect(207, 425, 64, 20), "Accept"))
            {
                talk = false;
                player.goOnQuest("Lost Parts");
                sp.SpawnAllParts();
            }
        }
    }
}
