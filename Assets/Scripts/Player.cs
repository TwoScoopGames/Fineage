using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

  private Rigidbody2D rb;

  public float thrust = 1f;
  public float dashMultiplier = 10f;
  public ForceMode2D mode = ForceMode2D.Force;

  public int speed = 1;
  public int attack = 1;
  public int health = 1;

  public int maxStamina = 1;
  public float stamina = 1f;
  public float dashStaminaCost = 1f;

  public float airGravityScale = 50f;

  public List<SkeletonAnimation> speedControlledAnimations = new List<SkeletonAnimation>();
  public List<Animator> speedControlledAnimators = new List<Animator>();

  void Start() {
    rb = GetComponent<Rigidbody2D>();
    stamina = maxStamina;
  }

  Vector2 direction = new Vector2();

  void FixedUpdate() {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");

    var amt = thrust * speed;

    direction = new Vector2();
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

      if (Input.GetButtonDown("dash") && stamina >= dashStaminaCost) {
        stamina -= dashStaminaCost;
        amt *= dashMultiplier;
      }

      rb.gravityScale = 0;
    } else {
      rb.gravityScale = airGravityScale;
    }
    direction = direction.normalized;

    rb.AddForce(direction * amt, mode);
  }

  void Update() {
    if (Input.GetKeyDown("t")) {
      SceneManager.LoadScene("Title");
    }

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
    foreach (var anim in speedControlledAnimators) {
      anim.speed = animationSpeed;
    }
  }


  protected void OnGUI()
  {
    GUI.skin.label.fontSize = Screen.width / 40;
    GUILayout.Label(string.Format("Stamina: {0} / {1}", stamina, maxStamina));
    GUILayout.Label(string.Format("Health: {0}", health));
  }
}
