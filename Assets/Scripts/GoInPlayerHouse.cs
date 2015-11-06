using UnityEngine;
using System.Collections;

public class GoInPlayerHouse : MonoBehaviour {
	public Player player;
    private bool canEnter = false;
    private bool showEnterHomeGUI = false;

	void OnTriggerEnter(Collider col)
	{
        
		if(col.gameObject.name == "Player")
		{
            if (player.hasDoneQuest("Spare Parts"))
            {
                Player.test = true;
                canEnter = true;
                showEnterHomeGUI = true;
                Debug.Log("Player may enter the house now.");
            }
		}
	}

    void OnGUI()
    {
        if (showEnterHomeGUI)
        {
            GUI.Box(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 25), "Enter Home (E)");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canEnter)
        {
            Application.LoadLevel("PlayerRoom");
        }
    }
}
