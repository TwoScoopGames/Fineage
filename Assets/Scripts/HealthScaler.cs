using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScaler : MonoBehaviour {

  private Player player;

  public int health = 1;
  public float scale = 1f;

  void Start() {
    var go = GameObjectExtensions.FindParentByTag(gameObject, "Player");
    player = go.GetComponent<Player>();

    player.health = health;
    var newScale = player.gameObject.transform.localScale.x * scale;
    player.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
  }

}
