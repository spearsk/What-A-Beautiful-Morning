using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
    public Player player;
    ArrayList itemsInInv = new ArrayList();

    public void AddToInventory(string obj)
    {
        itemsInInv.Add(obj);
    }

    public void RemoveFromInventory(string obj)
    {
        itemsInInv.Remove(obj);
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
