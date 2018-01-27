using UnityEngine;

public class SmoothCamera2D : MonoBehaviour {

  public float dampTime = 0.15f;
  private Vector3 velocity = Vector3.zero;
  public Transform target;

  public GameObject camera;
  private Camera cameraComponent;

  void Start() {
    cameraComponent = camera.GetComponent<Camera>();
  }

  void Update()
  {
    if (target)
    {
      Vector3 point = cameraComponent.WorldToViewportPoint(target.position);
      Vector3 delta = target.position - cameraComponent.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
      Vector3 destination = transform.position + delta;
      transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
  }
}
