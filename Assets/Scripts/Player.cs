using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private Rigidbody2D rb;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
  }

  public float thrust = 1f;
  public float dashMultiplier = 10f;
  public ForceMode2D mode = ForceMode2D.Force;

  void Update () {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");

    var direction = new Vector2();
    if (horizontal < 0) {
      direction += Vector2.left;
    }
    if (horizontal > 0) {
      direction += Vector2.right;
    }
    if (vertical < 0) {
      direction += Vector2.down;
    }
    if (vertical > 0) {
      direction += Vector2.up;
    }
    var amt = thrust;
    if (Input.GetKeyDown("space")) {
      amt *= dashMultiplier;
    }
    rb.AddForce(direction * amt, mode);
  }
}
