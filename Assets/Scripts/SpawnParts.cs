using UnityEngine;

public class SpawnParts : MonoBehaviour {
    public Transform[] prefab;
    public bool SpawnStuff = false;

    public void SpawnAllParts()
    {
         Object.Instantiate(prefab[0], new Vector3(-8f, 2, -12f), transform.rotation);
         Object.Instantiate(prefab[1], new Vector3(-57f, 2, 21f), transform.rotation);
         Object.Instantiate(prefab[2], new Vector3(-104f, 2, 35f), transform.rotation);
        Object.Instantiate(prefab[3], new Vector3(-33f, 2, 78f), transform.rotation);

    }

    void Start()
    {
    }

    void Update()
    {
        if(SpawnStuff == true)
        {
            SpawnAllParts();
        }
    }
}
