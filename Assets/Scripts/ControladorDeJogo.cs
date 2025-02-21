using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeJogo : MonoBehaviour {
  public static ControladorDeJogo instancia;

  public int checkpoint = 0;
  public int hpMaximo = 3;
  public int hp = 3;

  
  void Awake() {
    if(instancia == null) {
      instancia = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  public void Start() {
    Debug.LogWarning("Iniciando o controlador");

    if(PlayerPrefs.HasKey("fase_atual")) {
      string nomeDaFase = PlayerPrefs.GetString(("fase_atual"));

      Debug.LogWarning("Fase atual salva: " + nomeDaFase);
      
      SceneManager.LoadScene(nomeDaFase);
    } else {
      Debug.LogWarning("Nao tem informacao salva");
    }
  }

}
