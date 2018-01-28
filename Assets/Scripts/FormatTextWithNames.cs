using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormatTextWithNames : MonoBehaviour {

  void Start () {
    var text = GetComponent<Text>();

    text.text = string.Format(@"{0} successfully passed on it’s genetic information.

When {0} passes away, it’s legacy lives on.

A new generation is growing. Which trait would you like to modify?", GameManager.Instance.currentName, GameManager.Instance.previousName);
  }
}
