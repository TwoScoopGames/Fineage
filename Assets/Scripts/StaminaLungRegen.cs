using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaLungRegen : MonoBehaviour {

  private Player player;

  public int maxStamina = 1;
  public float staminaRegenPerSecond = 1f;

  void Start() {
    var go = GameObjectExtensions.FindParentByTag(gameObject, "Player");
    player = go.GetComponent<Player>();

    player.maxStamina = maxStamina;
    player.stamina = maxStamina;
  }

  void Update() {
    var maxRegen = Time.deltaTime * staminaRegenPerSecond;
    var minRegen = 0;
    var pct = player.gameObject.transform.position.y > -20f ? 1f : 0f;
    var amt = Mathf.Lerp(minRegen, maxRegen, pct);
    player.stamina = Mathf.Min(maxStamina, player.stamina + amt);
  }
}
