using UnityEngine;
using System.Collections;

public class Enemy_2 : MonoBehaviour {
	//This script should be attached to enemy two prefab
	//If shoot with a bullet two times, dies
	//After first shot, duplicates its velocity
	public float speed;
	int shot;
    GameObject mainCam;
	// Use this for initialization
	void Start () {
		shot = 0;
        mainCam = GameObject.Find("Main Camera");
        Debug.Log(mainCam);
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y < 0f)
            Destroy(gameObject);
		transform.Translate (0, 0, -1 * speed * Time.deltaTime, Space.World);
	}
	//If collides with a bullet, both should be destroyed
	void OnCollisionEnter(Collision c)
	{
		GameObject go = c.gameObject;
		if (go.layer == 11) {
			if (shot > 1) {
                //Destroy components
               
				Destroy (gameObject);
                mainCam.GetComponent<Logic>().incScore(2);

				shot = 0;
            } 
			else {
                speed = speed * 2;
				shot++;
            }
            Destroy(go);
        }
        else if (go.layer == 9)  //Destroy Ally
        {
            Destroy(go);
        }
        else if (go.layer == 10) //Kittens
        {
            mainCam.GetComponent<Logic>().decScore(2);
            mainCam.GetComponent<Logic>().lives--;
            Destroy(go);
        }
    }

}
