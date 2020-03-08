using UnityEngine;
using System.Collections;
using System;

public class EnemiesList : IComparable<EnemiesList> {
	
	public GameObject objeto;
	public int vida;
	public string nome;
	public GameObject alvo;
	
	public EnemiesList(string NewNome, GameObject newObjeto, int newVida, GameObject newAlvo){
		objeto = newObjeto;
		vida = newVida;
		nome= NewNome;
		alvo = newAlvo;
	}
	
	public int CompareTo(EnemiesList other){
		if(other == null){
			return 1;
		}
		
		return vida - other.vida;
	}
	
}