using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    int score = 0;
    public int lives;
    public int scoreMultiplier = 10;
    Vector3[] SPs = new Vector3[8];
    GameObject[] enemies = new GameObject[2];
    public GameObject Enemy1, Enemy2;

    // Use this for initialization
    void Start()
    {
        SPs[0] = new Vector3(-14.43f,1.2f, 10.75f);
        SPs[1] = new Vector3(-10.42f, 1.2f, 10.75f);
        SPs[2] = new Vector3(-6f, 1.2f, 10.75f);
        SPs[3] = new Vector3(-1.85f, 1.2f, 10.75f);
        SPs[4] = new Vector3(2.16f, 1.2f, 10.75f);
        SPs[5] = new Vector3(6.31f, 1.2f, 10.75f);
        SPs[6] = new Vector3(10.46f, 1.2f, 10.75f);
        SPs[7] = new Vector3(14.27f, 1.2f, 10.75f);
        enemies[0] = Enemy1;
        enemies[1] = Enemy2;

        StartCoroutine(SampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
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
        GUI.Label(new Rect(0, 0, 100, 50), "Score: " + score);
        GUI.Label(new Rect(400, 0, 100, 50), "Lives: " + lives);
    }

    IEnumerator SampleCoroutine()
    {
        while (lives > 0)
        {
            yield return new WaitForSeconds(2);
            int i = Random.Range(0, 8);
            int type = Random.Range(0, 2);
            GameObject catLady = Instantiate(enemies[type]);
            catLady.GetComponent<Transform>().position = (SPs[i]);
        }

    }

}
