using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jogador : MonoBehaviour {

  public float velocidade;
  public float velocidadePulo;
  public Rigidbody2D corpo;

  public Transform[] posicioesIniciais;


  void Start() {
    Debug.Log("Iniciou a cena!");
    transform.position = posicioesIniciais[ControladorDeJogo.instancia.checkpoint].position;
  }

  void Update() {

    if(Input.GetKey(KeyCode.RightArrow)) {
      corpo.velocity = new Vector3(velocidade, corpo.velocity.y, 0f);
    }
    if(Input.GetKey(KeyCode.LeftArrow)) {
      corpo.velocity = new Vector3(-velocidade, corpo.velocity.y, 0f);
    }

    if(Input.GetKey(KeyCode.Space)) {
      corpo.velocity = new Vector3(corpo.velocity.x, velocidadePulo, 0f);
    }
  }

  public void OnTriggerEnter2D(Collider2D collision) {
    if(collision.gameObject.tag == "Morte") {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    if(collision.gameObject.tag == "Checkpoint") {
      Debug.LogWarning("Colidiu com o checkpoint!!!");
      ControladorDeJogo.instancia.checkpoint = 1;
    }

  }
}
