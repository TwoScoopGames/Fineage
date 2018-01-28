using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAdjuster : MonoBehaviour {

  private Player player;

  public int attack = 0;

  void Start() {
    var go = GameObjectExtensions.FindParentByTag(gameObject, "Player");
    player = go.GetComponent<Player>();

    player.attack = attack;
  }
}
