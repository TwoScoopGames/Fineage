using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishUpgradeMenu : MonoBehaviour {

  public GameManager gameManager;
  /* private GameManager gameManagerComponent; */

  public Button respiratoryButton1;
  private Text respiratoryButton1Text;
  public Button respiratoryButton2;
  private Text respiratoryButton2Text;

  public Button bodyButton1;
  private Text bodyButton1Text;
  public Button bodyButton2;
  private Text bodyButton2Text;

  public Button headButton1;
  private Text headButton1Text;
  public Button headButton2;
  private Text headButton2Text;

  public Button tailButton1;
  private Text tailButton1Text;
  public Button tailButton2;
  private Text tailButton2Text;

  void Start() {
    respiratoryButton1Text = respiratoryButton1.transform.Find("Text").GetComponent<Text>();
    respiratoryButton2Text = respiratoryButton2.transform.Find("Text").GetComponent<Text>();

    bodyButton1Text = bodyButton1.transform.Find("Text").GetComponent<Text>();
    bodyButton2Text = bodyButton2.transform.Find("Text").GetComponent<Text>();

    headButton1Text = headButton1.transform.Find("Text").GetComponent<Text>();
    headButton2Text = headButton2.transform.Find("Text").GetComponent<Text>();

    tailButton1Text = tailButton1.transform.Find("Text").GetComponent<Text>();
    tailButton2Text = tailButton2.transform.Find("Text").GetComponent<Text>();


    if (gameManager.respiratory.children != null && gameManager.respiratory.children.Length > 0) {
      respiratoryButton1Text.text = gameManager.respiratory.children[0].prefabs["Gills"];
    } else {
      respiratoryButton1.gameObject.SetActive(false);
    }
    if (gameManager.respiratory.children != null && gameManager.respiratory.children.Length > 1) {
      respiratoryButton2Text.text = gameManager.respiratory.children[1].prefabs["Gills"];
    } else {
      respiratoryButton2.gameObject.SetActive(false);
    }

    if (gameManager.body.children != null && gameManager.body.children.Length > 0) {
      bodyButton1Text.text = gameManager.body.children[0].prefabs["Body"];
    } else {
      bodyButton1.gameObject.SetActive(false);
    }
    if (gameManager.body.children != null && gameManager.body.children.Length > 1) {
      bodyButton2Text.text = gameManager.body.children[1].prefabs["Body"];
    } else {
      bodyButton2.gameObject.SetActive(false);
    }

    if (gameManager.head.children != null && gameManager.head.children.Length > 0) {
      headButton1Text.text = gameManager.head.children[0].prefabs["Head"];
    } else {
      headButton1.gameObject.SetActive(false);
    }
    if (gameManager.head.children != null && gameManager.head.children.Length > 1) {
      headButton2Text.text = gameManager.head.children[1].prefabs["Head"];
    } else {
      headButton2.gameObject.SetActive(false);
    }

    if (gameManager.tail.children != null && gameManager.tail.children.Length > 0) {
      tailButton1Text.text = gameManager.tail.children[0].prefabs["Tail"];
    } else {
      tailButton1.gameObject.SetActive(false);
    }
    if (gameManager.tail.children != null && gameManager.tail.children.Length > 1) {
      tailButton2Text.text = gameManager.tail.children[1].prefabs["Tail"];
    } else {
      tailButton2.gameObject.SetActive(false);
    }
  }

  void Update() {

  }

  public void StartOver() {
    gameManager.StartOver();
    SceneManager.LoadScene("Main");
  }

}
