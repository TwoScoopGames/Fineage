using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishUpgradeMenu : MonoBehaviour {

  public GameObject gameManager;
  private GameManager gameManagerComponent;

  public Button respiratoryButton1;
  public Button respiratoryButton2;

  public Button bodyButton1;
  public Button bodyButton2;

  public Button headButton1;
  public Button headButton2;

  public Button tailButton1;
  public Button tailButton2;

  void Start() {
    gameManagerComponent = gameManager.GetComponent<GameManager>();
  }

  void Update() {

  }

  public void StartOver() {
    gameManagerComponent.StartOver();
    SceneManager.LoadScene("Main");
  }

}
