using UnityEngine;
using System.Collections;

public class HitGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter(Collision collision) {
		Destroy(collision.gameObject);
	}
	
	void OnTriggerEnter(Collider collision) {
		Destroy (collision.gameObject);
	}
}