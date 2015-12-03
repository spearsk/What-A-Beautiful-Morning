using UnityEngine;
using System.Collections;

public class PlayerLastLevel : MonoBehaviour {
    public static bool test = false;
    int stopShowing = 0;
    public GameObject kyle;
    RobotKyleEnd rke;
    private bool showSleepTrigger = false;
    public static bool isNearBed = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Futon" && rke.spokenTo)
        {
            showSleepTrigger = true;
            isNearBed = true;
        }
    }

	// Use this for initialization
	void Start () {
        rke = kyle.GetComponent<RobotKyleEnd>();
	}

    void OnGUI ()
    {
        if (showSleepTrigger)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Sleep (E)");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E) && rke.spokenTo && isNearBed)
        {
            Application.LoadLevel("MainMenu");
        }
	}
}
