using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JogadorTopdown : MonoBehaviour {

  public Animator animador;
  public Rigidbody2D corpo;
  public float velocidade;


  /// <summary>
  /// baixo = direcao 0
  /// esquerda = direcao 1
  /// cima = direcao 2
  /// direita = direcao 3
  /// </summary>




  void Update() {
    corpo.velocity = Vector2.zero;

    if(Input.GetKey(KeyCode.RightArrow)) {
      animador.SetInteger("Direcao", 3);
      corpo.velocity = new Vector3(velocidade, corpo.velocity.y, 0f);
    }
    if(Input.GetKey(KeyCode.LeftArrow)) {
      animador.SetInteger("Direcao", 1);
      corpo.velocity = new Vector3(-velocidade, corpo.velocity.y, 0f);
    }

    if(Input.GetKey(KeyCode.UpArrow)) {
      animador.SetInteger("Direcao", 2);
      corpo.velocity = new Vector3(corpo.velocity.x, velocidade, 0f);
    }
    if(Input.GetKey(KeyCode.DownArrow)) {
      animador.SetInteger("Direcao", 0);
      corpo.velocity = new Vector3(corpo.velocity.x, -velocidade, 0f);
    }


    if(corpo.velocity != Vector2.zero) {
      animador.SetBool("Andando", true);
    } else {
      animador.SetBool("Andando", false);
    }
  }
}
