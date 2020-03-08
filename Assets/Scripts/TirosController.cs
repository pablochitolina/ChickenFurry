using UnityEngine;
using System.Collections;

public class TirosController : MonoBehaviour {
	public bool defTiro = true;
	public bool canon = false;
	public bool doze = false;

	public GameObject selectedTarget;
	public bool isSelectedTarget = false;

	public GameObject eggPistolaAtivo;
	public GameObject eggPistolaInativo;
	public GameObject eggMetralhadoraAtivo;
	public GameObject eggMetralhadoraInativo;
	public GameObject eggCanonAtivo;
	public GameObject eggCanonInativo;
	public GameObject eggDozeAtivo;
	public GameObject eggDozeInativo;
	public bool trocaTiro = false;
	public TextMesh qntdDoze;
	public TextMesh qntdCanon;


	// Use this for initialization
	void Start () {
	
	}

	public void SetButtons(bool eggDefAtivoBool, bool eggDozeAtivoBool, bool eggCanonAtivoBool ){
		trocaTiro = true;
		eggPistolaAtivo.SetActive(eggDefAtivoBool);
		eggPistolaInativo.SetActive(!eggDefAtivoBool);
		eggMetralhadoraAtivo.SetActive(eggDefAtivoBool);
		eggMetralhadoraInativo.SetActive(!eggDefAtivoBool);

		defTiro = eggDefAtivoBool;
		if (qntdCanon.text != "") {
			eggCanonAtivo.SetActive (eggCanonAtivoBool);
			eggCanonInativo.SetActive (!eggCanonAtivoBool);
			canon = eggCanonAtivoBool;
		}
		if (qntdDoze.text != "") {
			eggDozeAtivo.SetActive (eggDozeAtivoBool);
			eggDozeInativo.SetActive (!eggDozeAtivoBool);
			doze = eggDozeAtivoBool;
		}


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			//Debug.Log ("Raycast: " + hit.collider.gameObject.tag);
			if(hit.collider != null){
				if(hit.collider.tag == "defTiro"){
					SetButtons(true,false,false);
				}
				if(hit.collider.tag == "canon" && qntdCanon.text != ""){
					SetButtons(false,false,true);
				}
				if(hit.collider.tag == "doze" && qntdDoze.text != ""){
					SetButtons(false,true,false);
				}
				
			}
		}
	
	}
}
