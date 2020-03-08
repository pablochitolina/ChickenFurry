using UnityEngine;
using System.Collections;

public class EdgeScript : MonoBehaviour {
	public TirosController tirosControllerScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		//Debug.Log ("Trigger edge: " + coll.gameObject.tag);
		if (tirosControllerScript.isSelectedTarget) {
			if(tirosControllerScript.selectedTarget.name == coll.gameObject.name){
				tirosControllerScript.isSelectedTarget = false;
			}
		}
		if (coll.gameObject.tag == "eggMetralhadora" || coll.gameObject.tag == "eggPistola"|| coll.gameObject.tag == "eggCanon"|| coll.gameObject.tag == "eggDoze") {
			//tirosControllerScript.isSelectedTarget = false;
			Destroy (coll.gameObject);
		}
	}
}
