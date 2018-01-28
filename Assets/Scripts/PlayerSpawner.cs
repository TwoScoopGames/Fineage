using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

  void Start() {
    var player = GameManager.Instance.SpawnPlayer();
    player.transform.position = transform.position;
  }
}
