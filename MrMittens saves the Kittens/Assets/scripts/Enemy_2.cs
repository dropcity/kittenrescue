using UnityEngine;
using System.Collections;

public class Enemy_2 : MonoBehaviour {
	//This script should be attached to enemy two prefab
	//If shoot with a bullet two times, dies
	//After first shot, duplicates its velocity
	public float speed;
	int shot;
	// Use this for initialization
	void Start () {
		shot = 0;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0,speed*-1,0, Space.World);
	}
	//If collides with a bullet, both should be destroyed
	void OnCollisionEnter2D(Collision2D c)
	{
		GameObject go = c.gameObject;
		if (go.layer == 11) {
			Renderer r = go.GetComponent<Renderer> ();
			if (shot == 1) {				
				//Destroy components
				Destroy (r);
				DestroyObject (gameObject);
			} 
			else {
				Destroy (r);
				speed = speed * 2;
				shot++;
			}
		}
		// Destroy Ally 
		if (go.layer == 9) {

			Renderer r = go.GetComponent<Renderer>();
			Destroy(r);
		}
	}

}
