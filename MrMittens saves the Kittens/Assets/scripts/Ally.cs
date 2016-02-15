using UnityEngine;
using System.Collections;

public class Ally : MonoBehaviour {

	public int shooting_interval;
	public LayerMask lm;
	public GameObject ally;
	public Transform allyTransform;

	private int quantity_players;
	private GameObject clone;
	private Coroutine c;
	private float lifespan_ally;
	// Use this for initialization
	void Start () {
		
		quantity_players = 0;
		lifespan_ally = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {

		//only 3 allies are allowed at once
		if(quantity_players < 3){
		//Raycasting 
			if (Input.GetMouseButtonUp (0)) {

				Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (r, out hit, float.MaxValue, lm.value)) {

					if(lm.value != 8 && lm.value != 10 && lm.value != 9){

						//TODO: fix position
						clone = Instantiate (ally, hit.point, allyTransform.rotation) as GameObject;
						quantity_players++;
						c = StartCoroutine (DeleteAlly(clone));

					}
				
				}
			}
		}
	}

	IEnumerator DeleteAlly(GameObject clone){
	
		yield return new WaitForSeconds (lifespan_ally);

			DestroyObject (clone);
			quantity_players--;
	}
		
}
