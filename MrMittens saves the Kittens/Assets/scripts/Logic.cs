using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour {
    int score = 0;
    public int lives;
    public int scoreMultiplier = 100;
	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
	    if (lives == 0){
            SceneManager.LoadScene("GameOver");
        }

	}

    public void decScore(int units)
    {
        score -= units * scoreMultiplier;
    }
    public void incScore(int units)
    {
        score += units * scoreMultiplier;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "Score: "+ score);
        GUI.Label(new Rect(400, 0, 100, 50), "Lives: " + lives);
    }
}
