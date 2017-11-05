using UnityEngine;
using System.Collections;

public class sunkill : MonoBehaviour {
	bool respawn;
	float time;
	public GameObject broken;
	void Start(){
		respawn = false;
	}
	void OnTriggerEnter(Collider collider){
		respawn = true;
		Instantiate (broken, collider.transform.position, collider.transform.rotation);
		Destroy (collider.gameObject);
	}
	void Update(){
		if (respawn) {time += Time.deltaTime;}
		if (respawn && time>15) {
			respawn = false;
			Application.LoadLevel(0);
		}
	}
}
