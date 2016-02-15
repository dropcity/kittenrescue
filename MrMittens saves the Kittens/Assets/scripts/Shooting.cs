using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public float shootingInterval;
	public GameObject bullet;
	public Transform bulletSpawn;

	private GameObject clone;
	private Coroutine c;

	// Use this for initialization
	void Start () {

		c = StartCoroutine(ShootInterval());
	}

	void Update(){
		Debug.Log ("Bullet: " + clone.transform.position);
	}

	IEnumerator ShootInterval(){

		while(true){

			clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			//clone.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 10, ForceMode.Impulse);
			clone.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (new Vector3 (0,0, 10));
			//clone.transform.Translate (Vector3.forward);
			yield return new WaitForSeconds(shootingInterval);
		}
	}

	void OnTriggerEnter(Collider t){
		Debug.Log ("triggerd");
		Destroy (clone);
	}

}
