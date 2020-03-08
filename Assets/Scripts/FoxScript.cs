using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoxScript : MonoBehaviour {

	public GameObject fox;
	private GameObject inimigoEcolhidoInstance;
	private bool novo = false;
	
	private int forca = 30;
	public GameObject chicken;
	public List<EnemiesList> enemiesList;
	public GameObject dot;
	private Vector3 meio;
	private int numeroDots = 10;
	private GameObject dotInstance;
	public GameObject alvo;
	private Vector3 posNovoInimigo;
	private bool novoInimigo = false;

	// Use this for initialization
	void Start () {
		//tableEnemies = new Hashtable ();
		enemiesList = new List<EnemiesList> ();
	}
	
	public void NovoInimigo(Vector3 posN,bool nI){
		novo = true;
		posNovoInimigo = posN;
		novoInimigo = nI;
	}
	
	// Update is called once per frame
	void Update () {

		if (novoInimigo) {

			inimigoEcolhidoInstance = Instantiate (fox);
			inimigoEcolhidoInstance.name = "fox" + enemiesList.Count;
			inimigoEcolhidoInstance.transform.position = posNovoInimigo;
			enemiesList.Add(new EnemiesList(inimigoEcolhidoInstance.name,inimigoEcolhidoInstance,100,Instantiate (alvo)));
			inimigoEcolhidoInstance = Instantiate (fox);
			inimigoEcolhidoInstance.name = "fox" + enemiesList.Count;
			inimigoEcolhidoInstance.transform.position = posNovoInimigo;
			enemiesList.Add(new EnemiesList(inimigoEcolhidoInstance.name,inimigoEcolhidoInstance,100,Instantiate (alvo)));
			inimigoEcolhidoInstance = Instantiate (fox);
			inimigoEcolhidoInstance.name = "fox" + enemiesList.Count;
			inimigoEcolhidoInstance.transform.position = posNovoInimigo;
			enemiesList.Add(new EnemiesList(inimigoEcolhidoInstance.name,inimigoEcolhidoInstance,100,Instantiate (alvo)));
			novoInimigo = false;
			novo = false;
		}
		
		if (novo) {
			Vector3 pos;
			int r = Random.Range(0,8);
			switch(r){
			case 0:
				pos = new Vector3(-5f,5f,0f);
				break;
			case 1:
				pos = new Vector3(-5f,7f,0f);
				break;
			case 2:
				pos = new Vector3(-3f,7f,0f);
				break;
			case 3:
				pos = new Vector3(-1f,7f,0f);
				break;
			case 4:
				pos = new Vector3(1f,7f,0f);
				break;
			case 5:
				pos = new Vector3(3f,7f,0f);
				break;
			case 6:
				pos = new Vector3(5f,7f,0f);
				break;
			default:
				pos = new Vector3(5f,5f,0f);
				break;
			}
			
			inimigoEcolhidoInstance = Instantiate (fox);
			inimigoEcolhidoInstance.name = "fox" + enemiesList.Count;
			inimigoEcolhidoInstance.transform.position = pos;
			enemiesList.Add(new EnemiesList(inimigoEcolhidoInstance.name,inimigoEcolhidoInstance,100,Instantiate (alvo)));
			
			novo = false;
		}
		
		if(inimigoEcolhidoInstance != null){
			
			foreach(EnemiesList list in enemiesList){
				if(list.vida > 0){
					list.objeto.GetComponent<Rigidbody2D>().AddForce ((chicken.transform.position - list.objeto.transform.position).normalized * forca);
					for(int i = 1; i <= numeroDots; i ++){
						meio = (list.objeto.transform.position - chicken.transform.position) / 10 * i;
						dotInstance = Instantiate(dot);
						dotInstance.transform.position = new Vector3(meio.x,meio.y - 2.5f,2f);
						Destroy(dotInstance, 0.02f);
					}
					//list.alvo.transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 ((chicken.transform.position.y - list.objeto.transform.position.y ), (chicken.transform.position.x - list.objeto.transform.position.x)) * Mathf.Rad2Deg + 90);
					//list.alvo.transform.position = chicken.transform.position;
				}

			}
			
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "eggPistola" || coll.gameObject.tag == "eggMetralhadora" || coll.gameObject.tag == "eggCanon" || coll.gameObject.tag == "eggDoze") {
			
			Destroy(coll.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		//Debug.Log ("Trigger " + coll.gameObject.tag);
		
	}
	
}