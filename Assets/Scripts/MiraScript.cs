using UnityEngine;
using System.Collections;

public class MiraScript : MonoBehaviour {
	public TirosController tirosControllerScript;
	public GameObject mira;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (tirosControllerScript.isSelectedTarget) {
			pos = new Vector3 (tirosControllerScript.selectedTarget.transform.position.x, tirosControllerScript.selectedTarget.transform.position.y, -8f);
			mira.transform.position = pos;
		} else {
			mira.transform.position = new Vector3(0f,-10f,0);
		}
	
	}
	void OnTriggerEnter2D(Collider2D coll){
		//Debug.Log ("Trigger mira: " + coll.gameObject.tag);

	}
}
