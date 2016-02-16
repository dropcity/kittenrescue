using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Enemy : MonoBehaviour {
	
	public float speed;
	public int maxShots;

	private int shot;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, -1 * speed * Time.deltaTime, Space.World);
		//transform.Translate (0,speed*-1,0, Space.World);
	}

	void OnCollisionEnter(Collision c)
	{
		Debug.Log ("Collision with enemy shots: " + shot);

		GameObject collider = c.gameObject;
		Renderer r_collider = collider.GetComponent<Renderer> ();
		GameObject clone = GameObject.Find ("Enemy(Clone)");
		Renderer r_clone = clone.GetComponent<Renderer> ();

		if (collider.layer == 11) {
			Debug.Log ("Collision with bullet");
			if (shot == maxShots) {

				Debug.Log ("Enemy should get destroyed shot = " + shot);
				Destroy (r_clone);
				Destroy (clone);
			} 
			else {
				Destroy (r_collider);
				Destroy (collider);
				//speed = speed * 2;
				shot++;
			}
		}
		// Destroy Ally 
		if (collider.layer == 9) {

			Destroy(r_collider);
			Destroy (collider);
		}
	}

}
