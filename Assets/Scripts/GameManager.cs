using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public GameObject playerPrefab;

  public TechTreeNode body;
  public TechTreeNode head;
  public TechTreeNode respiratory;
  public TechTreeNode tail;

  void Start() {
    DontDestroyOnLoad(gameObject);

    StartOver();
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

    var player = Object.Instantiate(playerPrefab);
    var playerComponent = player.GetComponent<Player>();
    smoothCamera.target = player.transform;

    body.Spawn(player, playerComponent);
    head.Spawn(player, playerComponent);
    respiratory.Spawn(player, playerComponent);
    tail.Spawn(player, playerComponent);

    return player;
  }
}
