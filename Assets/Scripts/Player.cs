using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private Rigidbody2D rb;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
  }

  public float thrust = 1f;
  public ForceMode2D mode = ForceMode2D.Force;

  void Update () {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");
    if (horizontal < 0) {
      rb.AddForce(Vector2.left * thrust, mode);
    }
    if (horizontal > 0) {
      rb.AddForce(Vector2.right * thrust, mode);
    }
    if (vertical < 0) {
      rb.AddForce(Vector2.down * thrust, mode);
    }
    if (vertical > 0) {
      rb.AddForce(Vector2.up * thrust, mode);
    }
  }
}
