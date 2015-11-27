using UnityEngine;

public class SpawnDestroyer : MonoBehaviour {
    public Transform prefab;
    public bool spawnDestroyer = false;

    public void SpawnIt()
    {
         Object.Instantiate(prefab, new Vector3(-66, -1.4f, 25f), transform.rotation);
    }

    void Start()
    {
    }

    void Update()
    {
        if(spawnDestroyer == true)
        {
            SpawnIt();
        }
    }
}
