using UnityEngine;
using System.Collections;

public class PostSleepPlayer : MonoBehaviour {
    public PlayerInRoom player;
	// Use this for initialization
	void Start () {
        player.hasSlept = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
