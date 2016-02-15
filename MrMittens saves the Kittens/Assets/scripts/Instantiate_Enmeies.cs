using UnityEngine;
using System.Collections;

public class Instantiate_Enmeies : MonoBehaviour {


	public GameObject enemy;
	public Transform spawnPos;

	private Coroutine c;
	private GameObject clone;
	// Use this for initialization
	void Start () {
		c = StartCoroutine (CreateEnemy ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator CreateEnemy(){

		while (true) {
			clone = Instantiate (enemy, spawnPos.position, spawnPos.rotation) as GameObject;
			yield return new WaitForSeconds (4);
		}
	}
}
