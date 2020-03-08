using UnityEngine;
using System.Collections;

public class DropEnemiesScript : MonoBehaviour {

	public GameObject fox;
	public GameObject croc;
	public GameObject wolf;

	private float proximoEnimie = 10f;
	private float intervalo = 15f;
	private float minimo = 10f;
	private Vector3 pos;
	private GameObject enemieInstance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		proximoEnimie -= Time.deltaTime;
		if (proximoEnimie <= 0) {
			int p = Random.Range(0,5);
			switch(p){
			case 0:
				pos = new Vector3(-2f,7f,-3f);
				break;
			case 1:
				pos = new Vector3(-1f,7f,-3f);
				break;
			case 2:
				pos = new Vector3(0f,7f,-3f);
				break;
			case 3:
				pos = new Vector3(1f,7f,-3f);
				break;
			default:
				pos = new Vector3(1f,7f,-3f);
				break;
			}
			
			int t = Random.Range(0,3);
			switch(t){
			case 0:
				enemieInstance = Instantiate(fox);
				enemieInstance.transform.position = pos;
				break;
			case 1:
				enemieInstance = Instantiate(croc);
				enemieInstance.transform.position = pos;
				break;
			default:
				enemieInstance = Instantiate(wolf);
				enemieInstance.transform.position = pos;
				break;
			}
			enemieInstance.GetComponent<Rigidbody2D>().isKinematic = false;
			Destroy(enemieInstance,6f);
			
			proximoEnimie = Random.Range(minimo, intervalo+minimo);
		}
	}
}
