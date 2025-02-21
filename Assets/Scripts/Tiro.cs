using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

  public Rigidbody2D corpo;
  public float velocidade;
  public SpriteRenderer renderizador;

  //public void Start() {

  //}


  public void IniciarVelocidade(bool vaiPraDireita) {
    if(vaiPraDireita) {
      renderizador.flipX = false;
      corpo.velocity = Vector2.right * velocidade;
    } else {
      renderizador.flipX = true;
      corpo.velocity = Vector2.left * velocidade;
    }
    
  }



  public void OnCollisionEnter2D(Collision2D collision) {
    Destroy(gameObject);
  }

  public void OnTriggerEnter2D(Collider2D collision) {
    if(collision.gameObject.tag == "Inimigo") {
      Destroy(collision.gameObject);
    }

    if(collision.gameObject.tag != "Untagged") {
      Destroy(gameObject);
    }
  }

}
