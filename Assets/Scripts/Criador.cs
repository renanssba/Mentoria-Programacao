using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criador : MonoBehaviour {

  public GameObject[] coelho;
  public int tempoEntreCoelhos;

  void Start() {
    StartCoroutine(FicarCriandoObjetos());
  }


  public IEnumerator FicarCriandoObjetos() {
    //int coelhosCriados = 0;
    while(true) {
      CriarObjeto();
      //coelhosCriados = coelhosCriados + 1;
      yield return new WaitForSeconds(tempoEntreCoelhos);
    }
  }

  public void CriarObjeto() {
    Instantiate(coelho[Random.Range(0, 3)], transform);//
  }

}
