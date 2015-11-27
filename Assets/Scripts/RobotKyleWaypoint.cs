using UnityEngine;
using System.Collections;

public class RobotKyleWaypoint : MonoBehaviour {
    public Player player;
    bool isIn = false;


    void OnTriggerEnter(Collider col)
    {
            Debug.Log("Player entered the trigger");
            isIn = true;

    }

    void OnTriggerExit(Collider col)
    {
            Debug.Log("Player left the trigger");
            isIn = false;
    }

    public bool isTrue()
    {
        return isIn;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
