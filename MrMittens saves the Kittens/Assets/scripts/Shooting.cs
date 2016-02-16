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
		//Debug.Log ("Bullet: " + clone.transform.position);
	}

	IEnumerator ShootInterval(){

		while(true){

			clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
/*<<<<<<< HEAD
			//clone.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 10, ForceMode2D.Impulse);
			clone.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (new Vector3 (0,10, 0));
=======*/
			//clone.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 10, ForceMode.Impulse);
			clone.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (new Vector3 (0,10,0));
			//clone.transform.Translate (Vector3.forward);
//>>>>>>> refs/remotes/origin/master
			yield return new WaitForSeconds(shootingInterval);
		}
	}

	void OnTriggerEnter(Collider t){
		Debug.Log ("triggerd");
		Destroy (clone);
	}

}
