using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdjuster : MonoBehaviour {

  private Player player;

  public float speed = 1f;
  public float dashStaminaCost = 1f;

  void Start() {
    var go = GameObjectExtensions.FindParentByTag(gameObject, "Player");
    player = go.GetComponent<Player>();

    player.speed = speed;
    player.dashStaminaCost = dashStaminaCost;
  }
}
