using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour {
	//This script should be attached to enemy one prefab
	//If shoot with a bullet, should die
	public float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine (MoveEnemy());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//If collides with a bullet, both should be destroyed
	void OnCollisionEnter(Collision c)
	{
		GameObject go = c.gameObject;
		Debug.Log ("go.layer " + go.layer);

		if (go.layer == 11) {
			Renderer r = go.GetComponent<Renderer>();
			//Destroy components
			Destroy(r);
			DestroyObject (gameObject);
			Destroy (go);
		}
		// Destroy Ally 

		if (go.layer == 9) {
			Renderer r = go.GetComponent<Renderer>();
			Destroy(r);
			Destroy (go);
		}
	}

	IEnumerator MoveEnemy(){

		while (true) {
			transform.Translate (0, 0, -1 * speed, Space.World);
			yield return new WaitForSeconds (0.09f);
		}
	}
		
}
