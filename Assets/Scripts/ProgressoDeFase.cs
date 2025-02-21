using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressoDeFase : MonoBehaviour {
  
  
  void Start() {
    StartCoroutine(EsperaUmFrameESalva());
  }

  public IEnumerator EsperaUmFrameESalva() {
    yield return null;
    yield return null;
    PlayerPrefs.SetString("fase_atual", SceneManager.GetActiveScene().name);
  }
}
