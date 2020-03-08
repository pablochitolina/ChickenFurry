using UnityEngine;
using System.Collections;

public class EggControllerScript : MonoBehaviour {
	public MetralhadoraScript eggMetralhadoraScript;
	public PistolaScript eggPistolaScript;
	public CanonScript eggCanonScript;
	public DozeScript eggDozeScript;
	public GameObject chicken;


	public AudioClip carregaMetralhadora;
	public AudioClip descarregaMetralhadora;
	public TirosController tirosController;
	public TirosController tirosControllerScript;
	
	private Vector3 angulo;
	private Vector2 enemieVectorPosition;

	private float delayTiro = 0f;
	public AudioClip carregaCanon;
	private bool tiroCanonBool;


	public AudioClip carregaDoze;
	private bool tiroDozeBool = false;

	private bool tiroDef = false;

	private bool fistShot = true;
	private float intervaloAtira = 0.1f;
	private float defIntervaloAtira = 0.1f;
	private float tempoCarrega = 0f;
	private bool carregouTiro = false;
	private bool carregadoDoze = false;
	private bool carregadoCanon = false;
	
	
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			//Debug.Log ("Raycast: " + hit.collider.gameObject.tag);
			if(hit.collider != null){

				if(hit.collider.tag == "wolf" || hit.collider.tag == "fox" || hit.collider.tag == "croc") {
					fistShot = true;
					carregouTiro = false;
					tirosControllerScript.selectedTarget = hit.collider.gameObject;
					tirosControllerScript.isSelectedTarget = true;
				}

				if(hit.collider.tag == "dozeTiroDrop"){
					Destroy(hit.collider.gameObject);
					if(tirosControllerScript.qntdDoze.text  == ""){
						tirosControllerScript.qntdDoze.text = "20";
						tirosControllerScript.eggDozeInativo.SetActive (true);
					}else{
						tirosControllerScript.qntdDoze.text = int.Parse(tirosControllerScript.qntdDoze.text) + 20 + "";
					}
					
				}
				if(hit.collider.tag == "canonTiroDrop"){
					Destroy(hit.collider.gameObject);
					if(tirosControllerScript.qntdCanon.text  == ""){
						tirosControllerScript.qntdCanon.text = "10";
						tirosControllerScript.eggCanonInativo.SetActive (true);
					}else{
						tirosControllerScript.qntdCanon.text = int.Parse(tirosControllerScript.qntdCanon.text) + 10 + "";
					}
				}
				
			}else{
				tirosControllerScript.isSelectedTarget = false;
			}
		}

	
		if (tirosController.defTiro && tirosControllerScript.isSelectedTarget) {
			Dir();

			if(!tiroDef){
				Dir();
				tiroDozeBool = false;
				tiroCanonBool = false;
				tiroDef = true;
				delayTiro = 0f;
			}


		}

		if (tiroDef) {

			if (!fistShot) {
				intervaloAtira -= Time.deltaTime;
				if (intervaloAtira < 0) {
					if(tirosControllerScript.isSelectedTarget){
						Dir();
						eggMetralhadoraScript.Atira (enemieVectorPosition, angulo, chicken);
						intervaloAtira = defIntervaloAtira;
					}
					tiroDef = false;
				}
				
			} else {
				if (!carregouTiro) {
					AudioSource.PlayClipAtPoint (carregaMetralhadora, transform.position, 1.0f);
					carregouTiro = true;
				}
				tempoCarrega += Time.deltaTime;
				if (tempoCarrega >= carregaMetralhadora.length) {
					fistShot = false;
					intervaloAtira = 0f;
					tempoCarrega = 0f;
				}
			}

		}



		if (tirosController.doze && tirosControllerScript.isSelectedTarget) {
			if(int.Parse(tirosControllerScript.qntdDoze.text) <= 0){
				fistShot = true;
				carregouTiro = false;
				tirosControllerScript.qntdDoze.text = "0";
				tirosControllerScript.SetButtons(true,false,false);
			}else if(!tiroDozeBool){
				Dir();
				AudioSource.PlayClipAtPoint (carregaDoze, transform.position, 1.0f);
				if(carregadoDoze){
					delayTiro = 10f;
				}else{
					delayTiro = 0f;
				}
				tiroDozeBool = true;
				tiroCanonBool = false;
				tiroDef = false;


			}
		}
		if (tiroDozeBool) {
			carregadoDoze = true;
			carregadoCanon = false;
			delayTiro += Time.deltaTime;
			if(delayTiro >= carregaDoze.length){
				if(tirosControllerScript.isSelectedTarget){
					carregadoDoze = false;
					tirosControllerScript.qntdDoze.text = int.Parse(tirosControllerScript.qntdDoze.text) - 1 + "";
					Dir();
					eggDozeScript.Atira (enemieVectorPosition, angulo);

				}
				tiroDozeBool = false;
			}
		}


		if (tirosController.canon && tirosControllerScript.isSelectedTarget) {
			if(int.Parse(tirosControllerScript.qntdCanon.text) <= 0){
				tirosControllerScript.qntdCanon.text = "0";
				fistShot = true;
				carregouTiro = false;
				tirosControllerScript.SetButtons(true,false,false);
			}else if(!tiroCanonBool){
				Dir();
				AudioSource.PlayClipAtPoint (carregaCanon, transform.position, 1.0f);
				if(carregadoCanon){
					delayTiro = 10f;
				}else{
					delayTiro = 0f;
				}
				tiroCanonBool = true;
				tiroDozeBool = false;
				tiroDef = false;

			}

		}
		if (tiroCanonBool) {
			carregadoDoze = false;
			carregadoCanon = true;
			delayTiro += Time.deltaTime;
			if(delayTiro >= carregaCanon.length){
				if(tirosControllerScript.isSelectedTarget){
					carregadoCanon = false;
					tirosControllerScript.qntdCanon.text = int.Parse(tirosControllerScript.qntdCanon.text) - 1 + "";
					Dir();
					eggCanonScript.Atira (enemieVectorPosition, angulo);
				}
				tiroCanonBool = false;
			}
		}

	}

	private void Dir(){
		enemieVectorPosition = tirosControllerScript.selectedTarget.transform.position;//new Vector3 (Input.mousePosition.x,Input.mousePosition.y + 2.5f,Input.mousePosition.z)
		angulo = new Vector3 (0, 0, Mathf.Atan2 ((enemieVectorPosition.y - transform.position.y + 2.5f), (enemieVectorPosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);
		chicken.transform.eulerAngles = angulo;

	}

	public void Para(){
		fistShot = true;
		if (carregouTiro) {
			AudioSource.PlayClipAtPoint (descarregaMetralhadora, transform.position, 1.0f);
			carregouTiro = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "croc" || coll.gameObject.tag == "fox" || coll.gameObject.tag == "wolf") {
			//Debug.Log ("EggScript TAG: " + coll.gameObject.name);
			
		}
	}
	
}