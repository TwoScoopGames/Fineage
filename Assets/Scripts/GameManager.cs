using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

  public TechTreeNode body;
  public TechTreeNode head;
  public TechTreeNode respiratory;
  public TechTreeNode tail;

  private static readonly GameManager instance = new GameManager();

  private GameManager() {
    StartOver();
  }

  public static GameManager Instance {
    get {
      return instance;
    }
  }

  public void StartOver() {
    body = TechTreeNode.firstBody;
    head = TechTreeNode.firstHead;
    respiratory = TechTreeNode.firstRespiratory;
    tail = TechTreeNode.firstTail;
  }

  public GameObject SpawnPlayer() {
    var camera = GameObject.Find("Main Camera");
    var smoothCamera = camera.GetComponent<SmoothCamera2D>();

    var prefab = CachedResource.Load<GameObject>("Player");
    var player = Object.Instantiate(prefab);
    var playerComponent = player.GetComponent<Player>();
    smoothCamera.target = player.transform;

    body.Spawn(player, playerComponent);
    head.Spawn(player, playerComponent);
    respiratory.Spawn(player, playerComponent);
    tail.Spawn(player, playerComponent);

    return player;
  }
}
