using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public int shootingInterval;
	public GameObject bullet;
	public Transform bulletSpawn;

	private GameObject clone;
	private Coroutine c;

	// Use this for initialization
	void Start () {

		c = StartCoroutine(ShootInterval());
	}

	IEnumerator ShootInterval(){

		while(true){

			clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			clone.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 10, ForceMode2D.Impulse);
			yield return new WaitForSeconds(shootingInterval);
		}
	}

	void OnTriggerEnter2D(Collider2D t){
		Destroy (clone);
	}

}
