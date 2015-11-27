using UnityEngine;
using System.Collections;

public class SetPlayerInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Player.isInHouse = true;
        Player.showNewPlayerHelp = false;
        Player.hasSlept = true;
        Player.nextScene = "PostDestructionCity";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
