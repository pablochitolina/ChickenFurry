using UnityEngine;
using System.Collections;

public class PistolaScript : MonoBehaviour {

	public FoxScript foxScript;
	public WolfScript wolfScript;
	public CrocScript crocScript;
	
	public AudioClip tiroPistola;
	public GameObject eggPistola;

	public TirosController tirosControllerScript;

	private GameObject eggInstance;
	private Rigidbody2D rbEgg;
	// Use this for initialization
	void Start () {
		
	}
	
	public void Atira(Vector2 mouseVectorPosition, Vector3 angulo){
		Tiro (angulo,mouseVectorPosition);
	}
	
	private void Tiro ( Vector3 angulo, Vector2 mouseVectorPosition){
		eggPistola.SetActive (true);
		eggInstance = Instantiate (eggPistola);
		eggInstance.transform.eulerAngles = angulo;
		eggPistola.SetActive (false);
		
		rbEgg = eggInstance.GetComponent<Rigidbody2D> ();
		rbEgg.AddForce (new Vector2(mouseVectorPosition.x,mouseVectorPosition.y + 2.5f).normalized * 500);
		
		AudioSource.PlayClipAtPoint (tiroPistola, transform.position, 1.0f);
		Destroy (eggInstance, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "fox") {//100
			
			foreach(EnemiesList list in foxScript.enemiesList){
				if(coll.gameObject.name == list.nome){
					list.vida -= 5;
					if(list.vida <=0){
						if(tirosControllerScript.selectedTarget.name == list.objeto.name){
							tirosControllerScript.isSelectedTarget = false;
						}
						Destroy(list.objeto);
						Destroy(list.alvo);
					}else{
						float scale = (float)list.vida / 100.0f;
						GameObject heath = GameObject.Find(list.nome + "/Healthbar/redBox/greenBox");
						heath.transform.localScale = new Vector3(scale,1,1);
					}
				}
			}
		}
		if (coll.gameObject.tag == "croc") {//200
			
			foreach(EnemiesList list in crocScript.enemiesList){
				if(coll.gameObject.name == list.nome){
					list.vida -= 5;
					if(list.vida <=0){
						if(tirosControllerScript.selectedTarget.name == list.objeto.name){
							tirosControllerScript.isSelectedTarget = false;
						}
						Destroy(list.objeto);
						Destroy(list.alvo);
					}else{
						float scale = (float)list.vida / 200.0f;
						GameObject heath = GameObject.Find(list.nome + "/Healthbar/redBox/greenBox");
						heath.transform.localScale = new Vector3(scale,1,1);
					}
				}
			}
			
		}
		if (coll.gameObject.tag == "wolf") {//150
			
			foreach(EnemiesList list in wolfScript.enemiesList){
				if(coll.gameObject.name == list.nome){
					list.vida -= 5;
					if(list.vida <=0){
						if(tirosControllerScript.selectedTarget.name == list.objeto.name){
							tirosControllerScript.isSelectedTarget = false;
						}
						Destroy(list.objeto);
						Destroy(list.alvo);
					}else{
						float scale = (float)list.vida / 150.0f;
						GameObject heath = GameObject.Find(list.nome + "/Healthbar/redBox/greenBox");
						heath.transform.localScale = new Vector3(scale,1,1);
					}
				}
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "dozeTiroDrop"){
			Destroy(coll.gameObject);
			if(tirosControllerScript.qntdDoze.text  == ""){
				tirosControllerScript.qntdDoze.text = "20";
				tirosControllerScript.eggDozeInativo.SetActive (true);
			}else{
				tirosControllerScript.qntdDoze.text = int.Parse(tirosControllerScript.qntdDoze.text) + 20 + "";
			}
			
		}
		if(coll.gameObject.tag == "canonTiroDrop"){
			Destroy(coll.gameObject);
			if(tirosControllerScript.qntdCanon.text  == ""){
				tirosControllerScript.qntdCanon.text = "10";
				tirosControllerScript.eggCanonInativo.SetActive (true);
			}else{
				tirosControllerScript.qntdCanon.text = int.Parse(tirosControllerScript.qntdCanon.text) + 10 + "";
			}
		}
		if(coll.gameObject.tag == "foxDrop"){
			foxScript.NovoInimigo(coll.gameObject.transform.position,true);
			Destroy(coll.gameObject);
			
		}
		if(coll.gameObject.tag == "wolfDrop"){
			wolfScript.NovoInimigo(coll.gameObject.transform.position,true);
			Destroy(coll.gameObject);
			
		}
		if(coll.gameObject.tag == "crocDrop"){
			crocScript.NovoInimigo(coll.gameObject.transform.position,true);
			Destroy(coll.gameObject);
			
		}
	}


}