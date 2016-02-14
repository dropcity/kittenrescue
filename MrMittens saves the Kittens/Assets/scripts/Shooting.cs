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
			yield return new WaitForSeconds(shootingInterval);
		}
	}

	void OnTriggerEnter(Collider t){
		Destroy (clone);
	}

}
