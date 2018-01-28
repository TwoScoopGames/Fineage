using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
  public float staminaRegenPerSecond = 1f;
  public float dashStaminaCost = 1f;

  public float airGravityScale = 50f;

  public GameObject[] speedControlledAnims;
  private SkeletonAnimation[] speedControlledAnimations;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
    stamina = maxStamina;
    speedControlledAnimations = speedControlledAnims.Select(o => o.GetComponent<SkeletonAnimation>()).ToArray();
  }

  void Update () {
    stamina = Mathf.Min(maxStamina, stamina + (Time.deltaTime * staminaRegenPerSecond));

    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");

    var amt = thrust * speed;

    var direction = new Vector2();
    if (horizontal < 0) {
      direction += Vector2.left;
    }
    if (horizontal > 0) {
      direction += Vector2.right;
    }
    if (transform.position.y < 0) {
      if (vertical < 0) {
        direction += Vector2.down;
      }
      if (vertical > 0) {
        direction += Vector2.up;
      }

      if (Input.GetKeyDown("space") && stamina >= dashStaminaCost) {
        stamina -= dashStaminaCost;
        amt *= dashMultiplier;
      }

      rb.gravityScale = 0;
    } else {
      rb.gravityScale = airGravityScale;
    }
    direction = direction.normalized;

    rb.AddForce(direction * amt, mode);

    var scale = transform.localScale;
    if ((direction.x > 0.01 || direction.x < -0.01) && Mathf.Sign(direction.x) != Mathf.Sign(scale.x)) {
      scale.x = -scale.x;
    }
    transform.localScale = scale;

    var angleZ = rb.velocity.y / 2000f * 45f;
    if (scale.x < 0) {
      angleZ *= -1;
    }
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angleZ), 0.5f);

    var animationSpeed = 0.5f + (rb.velocity.magnitude / 2000f);
    foreach (var anim in speedControlledAnimations) {
      anim.timeScale = animationSpeed;
    }
  }


  protected void OnGUI()
  {
    GUI.skin.label.fontSize = Screen.width / 40;
    GUILayout.Label(string.Format("{0} / {1}", stamina, maxStamina));
  }
}
