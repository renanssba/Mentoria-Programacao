using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeJogo : MonoBehaviour {
  public static ControladorDeJogo instancia;

  public int checkpoint = 0;

  
  void Awake() {
    if(instancia == null) {
      instancia = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }
  }


}
