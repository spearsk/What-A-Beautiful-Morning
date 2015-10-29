using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

//Should create multiple cubes as "buildings"
public class CityGenerator : EditorWindow {

    public GameObject buildingShape = null;
    private List<GameObject> buildings = new List<GameObject>();

    public float maxHeight = 10;
    public float minHeight = 4;
    public float chance = 15;
    public Vector3 citySize = new Vector3(20, 20, 20);

        [MenuItem("City/Generator")]
        static void Init()
    {
        CityGenerator window =  (CityGenerator)EditorWindow.GetWindow(typeof(CityGenerator));
    }

    public void OnGUI()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        buildingShape = EditorGUILayout.ObjectField(buildingShape, typeof(GameObject)) as GameObject;
#pragma warning restore CS0618 // Type or member is obsolete

        EditorGUILayout.Space();

        maxHeight = EditorGUILayout.FloatField("Max Height: ", maxHeight);
        minHeight = EditorGUILayout.FloatField("Min Height: ", minHeight);
        chance = EditorGUILayout.FloatField("Building Chance: ", chance);
        citySize = EditorGUILayout.Vector3Field("Map Size: ", citySize);

        if (GUILayout.Button("Create City"))
            CreateCity();
    }

    private void CreateCity()
    {
        foreach(GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (o.name.ToLower().Contains("(clone)"))
                GameObject.DestroyImmediate(o);
        }

        for (int x = (int)-citySize.x; x < citySize.x; x++)
        {
            for (int z = (int)-citySize.z; x < citySize.z; z++)
            {
                if (Random.Range(0.0f, 100.0f) <= chance)
                {
                    float height = Random.Range(minHeight, maxHeight);
                    Vector3 pos = new Vector3(x, height + 0.5f, z);

                    GameObject obj = GameObject.Instantiate(buildingShape, pos, Quaternion.identity) as GameObject;
                    obj.transform.localScale = new Vector3(height * 0.35f, height, height * 0.35f);

                    bool valid = true;
                    foreach(GameObject b in buildings)
                    {
                        if (obj.transform.GetComponent<Collider>().bounds.Intersects(b.GetComponent<Collider>().bounds))
                            valid = false;
                            break;
                    }

                    if (valid && obj != null)
                    {
                        buildings.Add(obj);
                        obj.transform.parent = GameObject.Find("Buildings").transform;
                    }
                }
            }
        }
    }
}
