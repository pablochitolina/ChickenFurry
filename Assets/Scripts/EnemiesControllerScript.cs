using UnityEngine;
using System.Collections;

public class EnemiesControllerScript : MonoBehaviour {

	public FoxScript foxScript;
	public WolfScript wolfScript;
	public CrocScript crocScript;
	
	private float tempoInimigo = 5.0f;
	private float defTempoInimigo = 5.0f;
	private bool fist = true;
	
	// Use this for initialization
	void Start () {


	}
	
	void Update () {
		if (fist) {
			tempoInimigo -= Time.deltaTime*2;;
		}
		tempoInimigo -= Time.deltaTime;
		if (tempoInimigo < 0) {
			fist = false;
			switch(Random.Range(0,3)){
			case 0:
				foxScript.NovoInimigo(new Vector3(0f,0f,0f), false);
				break;
			case 1:
				wolfScript.NovoInimigo(new Vector3(0f,0f,0f), false);
				break;	
			default:
				crocScript.NovoInimigo(new Vector3(0f,0f,0f), false);
				break;
			}
			tempoInimigo = defTempoInimigo;
		}
		
	}
	
}