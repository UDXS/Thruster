using UnityEngine;
using System.Collections;

public class despawn : MonoBehaviour {
	public float despawn_time;
	float current;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		current += Time.deltaTime;
		if (current >= despawn_time) {
			Destroy(gameObject);
		}
	}
}
