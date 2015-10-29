using UnityEngine;
using System.Collections;

public class CariumWaypoint : MonoBehaviour {
    public Player player;
    bool isIn = false;


    void OnTriggerEnter(Collider col)
    {
            Debug.Log("Player entered the trigger");
            isIn = player.isNowNear();

    }

    void OnTriggerExit(Collider col)
    {
            Debug.Log("Player left the trigger");
            isIn = player.isNotNear();
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
