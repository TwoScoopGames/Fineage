using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

  private AudioSource audioSource;

  public static SoundManager instance;

  void Awake () {
    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);

    audioSource = GetComponent<AudioSource>();
  }

  public void Play(AudioClip[] sounds, float volume = 1f) {
    if (sounds == null || sounds.Length == 0) {
      return;
    }
    int random = Random.Range(0, sounds.Length);
    audioSource.PlayOneShot(sounds[random], volume);
  }
}
