using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaMovementRegen : MonoBehaviour {

  private Player player;
  private Rigidbody2D rb;

  public int maxStamina = 1;
  public float staminaRegenPerSecond = 1f;
  public float minRegenPercent = 0.1f;

  void Start() {
    var go = GameObjectExtensions.FindParentByTag(gameObject, "Player");
    player = go.GetComponent<Player>();
    rb = go.GetComponent<Rigidbody2D>();

    player.maxStamina = maxStamina;
    player.stamina = maxStamina;
    Debug.Log(maxStamina);
  }

  void Update() {
    var maxRegen = Time.deltaTime * staminaRegenPerSecond;
    var minRegen = maxRegen * minRegenPercent;
    var pct = rb.velocity.magnitude / 2000;
    var amt = Mathf.Lerp(minRegen, maxRegen, pct);
    player.stamina = Mathf.Min(maxStamina, player.stamina + amt);
  }
}
