using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour {
	//This script should be attached to enemy one prefab
	//If shoot with a bullet, should die
	public float speed;
    GameObject mainCam;

    // Use this for initialization
    void Start () {
		StartCoroutine (MoveEnemy());
        mainCam = GameObject.Find("Main Camera");
        Debug.Log(mainCam);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 0f)
            Destroy(gameObject);
    }
	//If collides with a bullet, both should be destroyed
	void OnCollisionEnter(Collision c)
	{
		GameObject go = c.gameObject;
		//Debug.Log ("go.layer " + go.layer);

		if (go.layer == 11) {
			//Renderer r = go.GetComponent<Renderer>();
			//hit by bullet
			//Destroy(r);
			DestroyObject (gameObject);
			Destroy (go);
            mainCam.GetComponent<Logic>().incScore(1);
        }
		// Destroy Ally 

		if (go.layer == 9) {
			Renderer r = go.GetComponent<Renderer>();
			Destroy(r);
			Destroy (go);
		}
        if (go.layer == 10) //Kittens
        {
            mainCam.GetComponent<Logic>().decScore(2);
            mainCam.GetComponent<Logic>().lives--;
            Destroy(go);
        }
    }

	IEnumerator MoveEnemy(){

		while (true) {
			transform.Translate (0, 0, -1 * speed, Space.World);
			yield return new WaitForSeconds (0.09f);
		}
	}
		
}
