using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private Rigidbody2D rb;

  public float thrust = 1f;
  public float dashMultiplier = 10f;
  public ForceMode2D mode = ForceMode2D.Force;

  public int speed = 1;
  public int attack = 1;
  public int defense = 1;

  public int maxStamina = 1;
  private float stamina = 1f;
  public float staminRegenPerSecond = 1f;
  public float dashStaminaCost = 1f;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
    stamina = maxStamina;
  }

  void Update () {
    stamina = Mathf.Min(maxStamina, stamina + (Time.deltaTime * staminRegenPerSecond));

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
    direction = direction.normalized;

    var amt = thrust * speed;
    if (Input.GetKeyDown("space") && stamina >= dashStaminaCost) {
      stamina -= dashStaminaCost;
      amt *= dashMultiplier;
    }
    rb.AddForce(direction * amt, mode);

    var scale = transform.localScale;
    if ((rb.velocity.x > 0.01 || rb.velocity.x < -0.01) && Mathf.Sign(rb.velocity.x) != Mathf.Sign(scale.x)) {
      scale.x = -scale.x;
    }
    transform.localScale = scale;
  }


  protected void OnGUI()
  {
    GUI.skin.label.fontSize = Screen.width / 40;
    GUILayout.Label(string.Format("{0} / {1}", stamina, maxStamina));
  }
}
