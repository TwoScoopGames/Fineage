using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

  private GameManager gameManager;

  void Start() {
    var gm = GameObject.Find("GameManager");
    if (gm == null) {
      var prefab = CachedResource.Load<GameObject>("GameManager");
      gm = Object.Instantiate(prefab);
    }
    gameManager = gm.GetComponent<GameManager>();
    gameManager.SpawnPlayer();
  }
}
