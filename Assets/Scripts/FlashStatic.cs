using UnityEngine;
using System.Collections;

public class FlashStatic : MonoBehaviour {

    public bool showImage = false;
    public Texture screenStatic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (showImage)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screenStatic);
        }
    }
}
