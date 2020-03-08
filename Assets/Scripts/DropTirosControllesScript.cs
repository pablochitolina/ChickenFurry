using UnityEngine;
using System.Collections;

public class DropTirosControllesScript : MonoBehaviour {

	public GameObject doze;
	public GameObject canon;
	private float proximoTiro = 5f;
	private float intervalo = 10f;
	private float minimo = 5f;
	private Vector3 pos;
	private GameObject tiroInstance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		proximoTiro -= Time.deltaTime;
		if (proximoTiro <= 0) {
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

			int t = Random.Range(0,2);
			switch(t){
			case 0:
				tiroInstance = Instantiate(doze);
				tiroInstance.transform.position = pos;
				break;
			default:
				tiroInstance = Instantiate(canon);
				tiroInstance.transform.position = pos;
				break;
			}
			tiroInstance.GetComponent<Rigidbody2D>().isKinematic = false;
			Destroy(tiroInstance,6f);

			proximoTiro = Random.Range(minimo, intervalo+minimo);
		}
	}
}
