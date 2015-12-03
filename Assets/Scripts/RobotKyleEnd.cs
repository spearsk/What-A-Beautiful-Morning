using UnityEngine;
using System.Collections;

public class RobotKyleEnd : MonoBehaviour {
    string innerText = null;
    string dialogue = null;
    bool isClose = false;
    bool talk = false;
    bool highlighted = false;
    Vector2 scrollViewVector = Vector2.zero;
    int textLength = 335;
    public RobotKyleWaypoint ckw;
    string TaskToGive = "";
    public FlashStatic flash;
    public bool spokenTo = false;
	// Use this for initialization
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
        dialogue = "Listen, you don't need to trouble yourself with what you think you saw today. Just forget all about it; everything will be back as before by morning.";
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
            if (talk && isClose)
            {
                if (GUI.Button(new Rect(307, 425, 64, 20), "Goodbye"))
                {
                    talk = false;
                    StartCoroutine(RoboKyleMove());
                    spokenTo = true;
                }
            }
        }
    }
    IEnumerator RoboKyleMove()
    {
        flash.showImage = true;
        transform.position = new Vector3(100, 100, 100);
        yield return new WaitForSeconds(.25f);
        flash.showImage = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (ckw.isTrue())
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }
	}
}
