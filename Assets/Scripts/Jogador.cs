using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jogador : MonoBehaviour {

  public float velocidade;
  public float velocidadePulo;
  public Rigidbody2D corpo;
  public GameObject tiroPrefab;
  public SpriteRenderer renderizador;

  public Transform[] posicioesIniciais;


  void Start() {
    Debug.Log("Iniciou a cena!");
    transform.position = posicioesIniciais[ControladorDeJogo.instancia.checkpoint].position;
  }

  void Update() {

    if(Input.GetKey(KeyCode.RightArrow)) {
      renderizador.flipX = false;
      corpo.velocity = new Vector3(velocidade, corpo.velocity.y, 0f);
    }
    if(Input.GetKey(KeyCode.LeftArrow)) {
      renderizador.flipX = true;
      corpo.velocity = new Vector3(-velocidade, corpo.velocity.y, 0f);
    }

    if(Input.GetKeyDown(KeyCode.Space)) {
      corpo.velocity = new Vector3(corpo.velocity.x, velocidadePulo, 0f);
    }

    if(Input.GetKeyDown(KeyCode.E)) {
      Atirar();
    }
  }


  public void Atirar() {
    GameObject novoTiro = Instantiate(tiroPrefab, transform.position, Quaternion.identity);
    novoTiro.GetComponent<Tiro>().IniciarVelocidade(!renderizador.flipX);
  }



  public void OnTriggerEnter2D(Collider2D collision) {
    if(collision.gameObject.tag == "Morte") {
      Reviver();
    }

    if(collision.gameObject.tag == "Checkpoint") {
      Debug.LogWarning("Colidiu com o checkpoint!!!");
      ControladorDeJogo.instancia.checkpoint = 1;
    }

    if(collision.gameObject.tag == "Teleporte") {
      ControladorDeJogo.instancia.checkpoint = 0;
      SceneManager.LoadScene("Gameplay 2");
    }

    if(collision.gameObject.tag == "Inimigo") {
      ControladorDeJogo.instancia.hp = ControladorDeJogo.instancia.hp - 1;
      ControleDeUI.instancia.AtualizarUI();
      if(ControladorDeJogo.instancia.hp == 0) {
        Reviver();
      }
    }

  }

  public void Reviver() {
    ControladorDeJogo.instancia.hp = ControladorDeJogo.instancia.hpMaximo;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
