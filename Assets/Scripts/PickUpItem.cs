using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour
{
    private string collected;
    int numCollected = 0;
    private bool showGUI = false;
    private GameObject itemToDestroy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            itemCollected();
        }
    }

    void OnTriggerEnter(Collider col)
    { 

        if (col.gameObject.tag == "Player")
        {
            //Debug.Log(col + " has collided with " + this.gameObject);
            itemToDestroy = this.gameObject;
            showGUI = true;
        }
     }

    void OnGUI()
    {
        GUI.skin.box.wordWrap = true;
        if (showGUI == true)
        {
            GUI.Label(new Rect(Screen.width / 2 + Screen.width / 20, Screen.height / 3 + Screen.height / 3, 100, 100), "Take (T)");

        }

        GUI.Box(new Rect(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height / 3, 100, 100), "Number of parts collected: " + numCollected.ToString());
    }

    void itemCollected()
    {
        numCollected++;
        Destroy(itemToDestroy);
    }
}
