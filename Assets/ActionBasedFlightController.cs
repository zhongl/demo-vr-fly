using UnityEngine;
using UnityEngine.InputSystem;

public class ActionBasedFlightController : MonoBehaviour
{
  public float sensitive = 4f;
  public float rotationRange = 15f;
  public float cruiser = 5f;
  Rigidbody rb;

  float yaw;
  float pitch;
  float roll;
  bool accelerate;

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
  }

  void FixedUpdate()
  {
    ForceMode mode = accelerate ? ForceMode.Acceleration : ForceMode.Force;
    rb.AddForce(transform.forward * cruiser, mode);
  }

  private float clamp(float r, float max)
  {
    return Mathf.Clamp(r * sensitive * Time.deltaTime, -max, max);
  }

  void OnAccelerate(InputValue value)
  {
    accelerate = value.isPressed;
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
