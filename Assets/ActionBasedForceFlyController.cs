using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ActionBasedForceFlyController : MonoBehaviour
{
  public float sensitive = 4f;
  public float force = 3f;
  public float maxRotation = 15f;
  public ForceMode mode = ForceMode.Impulse;

  float forced;
  Rigidbody rb;

  float yaw;
  float pitch;
  float roll;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // void FixedUpdate()
  // {
  //   rb.AddForce(transform.forward * forced * force, mode);
  // }

  void Update()
  {
    transform.Rotate
    (
      clamp(pitch, maxRotation),
      clamp(yaw, maxRotation),
      clamp(yaw + roll, maxRotation)
    );
    transform.Translate(Vector3.forward * Time.deltaTime);
  }

  private float clamp(float r, float max)
  {
    return Mathf.Clamp(r * sensitive * Time.deltaTime, -max, max);
  }

  void OnPower(InputValue value)
  {
    forced = value.Get<float>();
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
