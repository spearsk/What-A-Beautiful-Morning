using UnityEngine;
using System.Collections;

public class PlayerInRoom : MonoBehaviour {
    private bool showSleepTrigger = false;
    public bool hasSlept = false;
    private bool isNearBed = false;
    private bool isNearDoor = false;
    bool showGoOutside = false;
    public float fadeSpeed = 1.5f;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Futon" && !hasSlept)
        {
            showSleepTrigger = true;
            isNearBed = true;
        }
        if (col.gameObject.name == "DoorCollider" && !hasSlept)
        {
            showGoOutside = true;
            isNearDoor = true;
        }
    }

    void OnGUI()
    {
        if (showSleepTrigger)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Sleep (E)");
        }

        if (hasSlept)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go outside and speak to Carium.");
        }

        if (!hasSlept)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3 - 50, 300, 50), "Go to your Futon to get some sleep.");
        }

        if (showGoOutside)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Go outside (E)");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isNearBed)
        {
            Application.LoadLevel("SleepScene");
        }

        if (Input.GetKeyUp(KeyCode.E) && isNearDoor)
        {
            //Application.LoadLevel("DestroyedWorld");
        }
    }
}
