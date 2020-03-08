using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DozeScript : MonoBehaviour {

	public GameObject bala1;
	public GameObject bala2;
	public GameObject bala3;
	public GameObject bala4;
	public GameObject bala5;
	public GameObject bala6;
	public GameObject bala7;
	public GameObject bala8;
	public GameObject bala9;
	public GameObject bala10;
	public GameObject bala11;
	public GameObject bala12;

	private GameObject eggInstance;
	private Rigidbody2D rbEgg;
	private ArrayList listEggs;
	public AudioClip tiroDoze;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Atira(Vector2 mouseVectorPosition, Vector3 angulo){
		listEggs = new ArrayList ();
		listEggs.Add (bala1);
		listEggs.Add (bala2);
		listEggs.Add (bala3);
		listEggs.Add (bala4);
		listEggs.Add (bala5);
		listEggs.Add (bala6);
		listEggs.Add (bala7);
		listEggs.Add (bala8);
		listEggs.Add (bala9);
		listEggs.Add (bala10);
		listEggs.Add (bala11);
		listEggs.Add (bala12);

		AudioSource.PlayClipAtPoint (tiroDoze, transform.position, 1.0f);

		foreach(GameObject egg in listEggs){
		
			eggInstance = Instantiate (egg);
			eggInstance.transform.eulerAngles = angulo;
			
			
			rbEgg = eggInstance.GetComponent<Rigidbody2D> ();
			rbEgg.AddForce (new Vector2(mouseVectorPosition.x,mouseVectorPosition.y + 2.5f).normalized * 1000);
			
			Destroy (eggInstance, 1.0f);
		}

	}

}
