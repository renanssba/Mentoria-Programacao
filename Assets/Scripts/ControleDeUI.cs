using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeUI : MonoBehaviour {
  public static ControleDeUI instancia;

  public GameObject[] coracoes;


  void Start() {
    instancia = this;
    AtualizarUI();
  }

  public void AtualizarUI() {
    for(int i=0; i<3; i++) {
      if(i < ControladorDeJogo.instancia.hp) {
        coracoes[i].SetActive(true);
      } else {
        coracoes[i].SetActive(false);
      }
    }
  }
}
