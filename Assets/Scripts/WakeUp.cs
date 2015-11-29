using UnityEngine;
using System.Collections;

public class WakeUp : MonoBehaviour {
	public GameObject Text1;
	public GameObject Text2;
    private bool cont = false;
	
	// Use this for initialization
	void Start () {
        Text1.SetActive(false);
        Text2.SetActive(false);
        Invoke("showFirst",2); // Enable the text so it shows
        Invoke("showSecond", 8); // Enable the text so it shows
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E) && cont && !Player.hasSlept)
        {
            Player.hasSlept = true;
            Application.LoadLevel("PlayerRoomPostSleep");
        }
	}

    void showFirst()
    {
        Text1.SetActive(true);
    }
    void hideFirst()
    {
        Text1.SetActive(false);
    }
    void showSecond()
    {
        Text2.SetActive(true);
        cont = true;
    }
    void hideSecond()
    {
        Text2.SetActive(false);
    }

}
