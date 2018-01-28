using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishUpgradeMenu : MonoBehaviour {

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

    if (GameManager.Instance.respiratory.children != null && GameManager.Instance.respiratory.children.Length > 0) {
      respiratoryButton1Text.text = GameManager.Instance.respiratory.children[0].name;
    } else {
      respiratoryButton1.gameObject.SetActive(false);
    }
    if (GameManager.Instance.respiratory.children != null && GameManager.Instance.respiratory.children.Length > 1) {
      respiratoryButton2Text.text = GameManager.Instance.respiratory.children[1].name;
    } else {
      respiratoryButton2.gameObject.SetActive(false);
    }

    if (GameManager.Instance.body.children != null && GameManager.Instance.body.children.Length > 0) {
      bodyButton1Text.text = GameManager.Instance.body.children[0].name;
    } else {
      bodyButton1.gameObject.SetActive(false);
    }
    if (GameManager.Instance.body.children != null && GameManager.Instance.body.children.Length > 1) {
      bodyButton2Text.text = GameManager.Instance.body.children[1].name;
    } else {
      bodyButton2.gameObject.SetActive(false);
    }

    if (GameManager.Instance.head.children != null && GameManager.Instance.head.children.Length > 0) {
      headButton1Text.text = GameManager.Instance.head.children[0].name;
    } else {
      headButton1.gameObject.SetActive(false);
    }
    if (GameManager.Instance.head.children != null && GameManager.Instance.head.children.Length > 1) {
      headButton2Text.text = GameManager.Instance.head.children[1].name;
    } else {
      headButton2.gameObject.SetActive(false);
    }

    if (GameManager.Instance.tail.children != null && GameManager.Instance.tail.children.Length > 0) {
      tailButton1Text.text = GameManager.Instance.tail.children[0].name;
    } else {
      tailButton1.gameObject.SetActive(false);
    }
    if (GameManager.Instance.tail.children != null && GameManager.Instance.tail.children.Length > 1) {
      tailButton2Text.text = GameManager.Instance.tail.children[1].name;
    } else {
      tailButton2.gameObject.SetActive(false);
    }
  }

  public void StartOver() {
    GameManager.Instance.StartOver();
    SceneManager.LoadScene("Main");
  }

  public void UpgradeRespiratory1() {
    GameManager.Instance.respiratory = GameManager.Instance.respiratory.children[0];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeRespiratory2() {
    GameManager.Instance.respiratory = GameManager.Instance.respiratory.children[1];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeBody1() {
    GameManager.Instance.body = GameManager.Instance.body.children[0];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeBody2() {
    GameManager.Instance.body = GameManager.Instance.body.children[1];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeHead1() {
    GameManager.Instance.head = GameManager.Instance.head.children[0];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeHead2() {
    GameManager.Instance.head = GameManager.Instance.head.children[1];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeTail1() {
    GameManager.Instance.tail = GameManager.Instance.tail.children[0];
    SceneManager.LoadScene("Main");
  }
  public void UpgradeTail2() {
    GameManager.Instance.tail = GameManager.Instance.tail.children[1];
    SceneManager.LoadScene("Main");
  }
}
