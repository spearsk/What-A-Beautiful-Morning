using UnityEngine;
using System.Collections;

public class PlayerMouseMovement : MonoBehaviour {
    float gridSize = 2.0f;
    Vector3 points;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, new Vector3(0, 1, 0));
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            points = ray.GetPoint(distance);
        }

        transform.position = new Vector3(Mathf.Round(points.x / gridSize) * gridSize, 1, Mathf.Round(points.z / gridSize) * gridSize);
    }
}
