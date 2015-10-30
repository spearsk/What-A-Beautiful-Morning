using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour {
    private Canvas CanvasObject;
 
     void Start()
    {
        CanvasObject = GetComponent<Canvas>();
        CanvasObject.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!CanvasObject.enabled)
            {
                Time.timeScale = 0;
                CanvasObject.enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                CanvasObject.enabled = false;
            }
        }
    }
}
