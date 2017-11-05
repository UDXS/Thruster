using UnityEngine;
using System.Collections;

public class shipcontrol : MonoBehaviour {
	public GameObject front_left;
	public GameObject front_right;
	bool front_thrusting;
	float lerpstoptime;
	bool notchecked;
	// Use this for initialization
	void Start () {
		front_thrusting = false;
		lerpstoptime = 0f;
		notchecked = true;
		DontDestroyOnLoad (gameObject);
	}
	void Update () {
		Rigidbody body = gameObject.GetComponent<Rigidbody> ();
		Transform loc = gameObject.GetComponent<Transform>();
		Debug.Log (Application.loadedLevel);
		if (Input.GetKey(KeyCode.LeftShift)) {
			body.AddRelativeForce(new Vector3(0,0,200),ForceMode.Acceleration);
			front_thrusting = true;
		}
		if (Input.GetKey(KeyCode.LeftControl)) {
			body.AddRelativeForce(new Vector3(0,0,-200),ForceMode.Acceleration);
			front_thrusting = false;
		}
		if (Input.GetKey(KeyCode.W)) {
			//body.AddRelativeTorque(0,110,0,ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.S)) {
			//body.AddRelativeTorque(0,-110,0,ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.A)) {
			body.AddRelativeTorque(-90,0,0,ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.D)) {
			body.AddRelativeTorque(90,0,0,ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.Q)) {
			//body.AddRelativeTorque(0,0,120,ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.E)) {
			//body.AddRelativeTorque(0,0,-120,ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.R)) {
			body.velocity = new Vector3(Mathf.Lerp(body.velocity.x,0,lerpstoptime),Mathf.Lerp(body.velocity.y,0,lerpstoptime),Mathf.Lerp(body.velocity.z,0,lerpstoptime));
			body.angularVelocity = new Vector3(Mathf.Lerp(body.angularVelocity.x,0,lerpstoptime),Mathf.Lerp(body.angularVelocity.y,0,lerpstoptime),Mathf.Lerp(body.angularVelocity.z,0,lerpstoptime));
			front_thrusting = false;
			lerpstoptime += 0.05f;
			if(lerpstoptime == 1f){
				lerpstoptime = 0;
			}
		}
		if (front_thrusting) {
			front_left.GetComponent<ParticleSystem>().enableEmission = true;
			front_right.GetComponent<ParticleSystem>().enableEmission = true;
		} else {
			front_left.GetComponent<ParticleSystem>().enableEmission = false;
			front_right.GetComponent<ParticleSystem>().enableEmission = false;
		}
	}
}
