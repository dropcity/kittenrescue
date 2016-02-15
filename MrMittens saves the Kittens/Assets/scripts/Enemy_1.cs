using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour {
	//This script should be attached to enemy one prefab
	//If shoot with a bullet, should die
	public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,-1*speed,0, Space.World);
	}
	//If collides with a bullet, both should be destroyed
	void OnCollisionEnter2D(Collision2D c)
	{
		GameObject go = c.gameObject;
		if (go.layer == 11) {
			Renderer r = go.GetComponent<Renderer>();
			//Destroy components
			Destroy(r);
			DestroyObject (gameObject);
		}
		// Destroy Ally 
		if (go.layer == 9) {
				
			Renderer r = go.GetComponent<Renderer>();
			Destroy(r);
		}
	}
		
}
