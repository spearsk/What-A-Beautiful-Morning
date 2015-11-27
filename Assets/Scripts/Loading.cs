using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    string scene = Player.nextScene;
    bool loaded = false;

    // Use this for initialization
    void Start () {
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        Invoke("showSecond", 2); // Enable the text so it shows
        Invoke("showThird", 3); // Enable the text so it shows
        Invoke("showFourth", 4); // Enable the text so it shows
    }

    void Update()
    {
        if (loaded)
        {
            Application.LoadLevel(scene);
        }
    }
    void showSecond()
    {
        Text2.SetActive(true);
    }
    void showThird()
    {
        Text3.SetActive(true);
    }
    void showFourth()
    {
        Text4.SetActive(true);
        loaded = true;
    }
}
