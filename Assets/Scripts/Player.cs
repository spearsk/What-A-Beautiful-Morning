using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Public variables that will show up in the Editor
	public float Acceleration = 50f;
	public float MaxSpeed = 20f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Get the player's input axes
		float xSpeed = Input.GetAxis("Horizontal");
		float zSpeed = Input.GetAxis("Vertical");
		// Get the movement vector
		Vector3 velocityAxis = new Vector3(xSpeed, 0, zSpeed);
		// Rotate the movement vector based on the camera
		velocityAxis = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up) * velocityAxis;

		// Move the player
		GetComponent<Rigidbody>().AddForce(velocityAxis.normalized * Acceleration);

		LimitVelocity();
	}

	/// <summary>
	/// Keeps the player's velocity limited so it will not go too fast.
	/// </summary>
	private void LimitVelocity() {
		Vector2 xzVel = new Vector2(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.z);
		if (xzVel.magnitude > MaxSpeed) {
			xzVel = xzVel.normalized * MaxSpeed;
			GetComponent<Rigidbody>().velocity = new Vector3(xzVel.x, GetComponent<Rigidbody>().velocity.y, xzVel.y);
		}
	}

}
