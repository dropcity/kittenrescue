using UnityEngine;
using System.Collections;

public class Ally : MonoBehaviour
{

    //first ally
    public GameObject ally_a;
    public Transform allyTransform_a;

    //second ally
    public GameObject ally_b;
    public Transform allyTransform_b;

    //first ally 
    private GameObject clone;
    //second ally
    //private GameObject clone_b;

    private int quantity_player_a;
    private int quantity_player_b;
    private Coroutine c;
    private float lifespan_ally;
    private bool switchAlly;

    // Use this for initialization
    void Start()
    {

        quantity_player_a = quantity_player_b = 0;
        lifespan_ally = 10.0f;
        switchAlly = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(1))
        {

            switchAlly = !switchAlly;
        }
        //Raycasting 
        if (Input.GetMouseButtonUp(0))
        {

            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(r, out hit, float.MaxValue))
            {
                //Debug.Log ("hit: " + hit.collider.name );

                if (hit.collider.name == "Ground")
                {

                    if (switchAlly == true && quantity_player_a < 3)
                    {

                        clone = Instantiate(ally_a, hit.point, allyTransform_a.rotation) as GameObject;
                        quantity_player_a++;
                        c = StartCoroutine(DeleteAlly(clone));

                    }
                    else if (switchAlly == false && quantity_player_b < 3)
                    {

                        clone = Instantiate(ally_b, hit.point, allyTransform_b.rotation) as GameObject;
                        quantity_player_b++;
                        c = StartCoroutine(DeleteAlly(clone));
                    }

                }

            }
        }
    }

    IEnumerator DeleteAlly(GameObject clone)
    {

        yield return new WaitForSeconds(lifespan_ally);

        DestroyObject(clone);
        if (clone.name == ally_a.name + "(Clone)")
        {
            quantity_player_a--;
        }
        else {
            quantity_player_b--;
        }

    }

}