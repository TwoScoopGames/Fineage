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

  public int maxStamina = 1;
  public int speed = 1;
  public int attack = 1;
  public int defense = 1;

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
    var amt = thrust * speed;
    if (Input.GetKeyDown("space")) {
      amt *= dashMultiplier;
    }
    rb.AddForce(direction * amt, mode);

    var scale = transform.localScale;
    if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(scale.x)) {
      scale.x = -scale.x;
    }
    transform.localScale = scale;
  }
}
