using UnityEngine;
using UnityEngine.InputSystem;

public class ActionBasedFlightController : MonoBehaviour
{
  public float sensitive = 4f;
  public float rotationRange = 15f;
  Rigidbody rb;

  float yaw;
  float pitch;
  float roll;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }
  void Update()
  {
    transform.Rotate
    (
      clamp(pitch, rotationRange),
      clamp(yaw, rotationRange),
      clamp(yaw + roll, rotationRange)
    );
    transform.Translate(Vector3.forward * Time.deltaTime);
  }

  private float clamp(float r, float max)
  {
    return Mathf.Clamp(r * sensitive * Time.deltaTime, -max, max);
  }

  void OnPower(InputValue value)
  {
    Debug.Log(value.Get<float>());
  }

  void OnYaw(InputValue value)
  {
    yaw = value.Get<float>();
  }
  void OnRoll(InputValue value)
  {
    roll = value.Get<float>();
  }
  void OnPitch(InputValue value)
  {
    pitch = value.Get<float>();
  }
}
