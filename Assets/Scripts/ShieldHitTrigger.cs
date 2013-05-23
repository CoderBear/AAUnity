using UnityEngine;
using System.Collections;

public class ShieldHitTrigger : MonoBehaviour
{
	public GameObject shieldHitAnim;
	
	void OnTriggerEnter (Collider collision)
	{
		Physics.IgnoreLayerCollision(8, 9, true);
		Debug.Log ("AAUNITY/GAME Shield Hit by " + collision.gameObject.tag);
		Debug.Log ("AAUNITY/GAME Shield Triggered");
		Vector3 position = collision.gameObject.transform.position;
			
		Instantiate (shieldHitAnim, position, Quaternion.identity);
		if(collision.gameObject.tag == "RottenApple")
			Destroy (collision.gameObject);
	}
}