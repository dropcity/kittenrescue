using UnityEngine;
using System.Collections;

public class Kitten : MonoBehaviour {
    public GameObject mainCam;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 0f)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collider c)
    {
        GameObject catLady = c.gameObject;
        mainCam.GetComponent<Logic>().decScore(2);
        mainCam.GetComponent<Logic>().lives--;
        Destroy(catLady);
    }
}

