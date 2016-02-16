using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter(Collider t){
		
		if (t.gameObject.layer == 11) {
			
			Renderer r = t.gameObject.GetComponent<Renderer>();
			Destroy(r);
			Destroy (t);
		}



	}
}
