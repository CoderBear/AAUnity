using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	
	tk2dSprite sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<tk2dSprite>();
	}
	
	// Update is called once per frame
	void Update () {
		float fallSpeed = 400 * Time.deltaTime;
		sprite.transform.position -= new Vector3(0,fallSpeed,0);		
	}
}