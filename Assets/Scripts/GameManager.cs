using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public GameObject playerPrefab;

  private TechTreeNode body;
  private TechTreeNode head;
  private TechTreeNode gills;
  private TechTreeNode tail;

  void Start() {
    DontDestroyOnLoad(gameObject);

    StartOver();
    SpawnPlayer();
  }

  public void StartOver() {
    body = TechTreeNode.firstBody;
    head = TechTreeNode.firstHead;
    gills = TechTreeNode.firstGills;
    tail = TechTreeNode.firstTail;
  }

  public GameObject SpawnPlayer() {
    var camera = GameObject.Find("Main Camera");
    var smoothCamera = camera.GetComponent<SmoothCamera2D>();

    var player = Object.Instantiate(playerPrefab);
    var playerComponent = player.GetComponent<Player>();
    smoothCamera.target = player.transform;

    body.Spawn(player, playerComponent);
    head.Spawn(player, playerComponent);
    gills.Spawn(player, playerComponent);
    tail.Spawn(player, playerComponent);

    return player;
  }

  void Update() {
  }
}
