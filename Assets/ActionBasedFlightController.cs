using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ActionBasedFlightController : MonoBehaviour
{
  public float sensitive = 4f;
  public float rotationRange = 15f;
  public float cruiser = 5f;
  public GameObject model;

  Rigidbody rb;
  float yaw;
  float pitch;
  float roll;
  bool accelerate;
  float invert = 1;
  Vector3 initP;
  Quaternion initR;
  float velocityX = 0.0f;
  float velocityY = 0.0f;
  float velocityZ = 0.0f;

  float smoothTime = 0.5f;

  float moving = 0f;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    initP = transform.position;
    initR = transform.rotation;
  }
  void Update()
  {
    clampRotate(model.transform);
    rotate(transform);
    var x = accelerate ? 2 : 1;
  }

  private void clampRotate(Transform t)
  {
    t.localEulerAngles = new Vector3
    (
        Mathf.SmoothDampAngle(model.transform.localEulerAngles.x, invert * pitch * rotationRange, ref velocityX, smoothTime),
        Mathf.SmoothDampAngle(model.transform.localEulerAngles.y, invert * yaw * rotationRange, ref velocityY, smoothTime),
        Mathf.SmoothDampAngle(model.transform.localEulerAngles.z, invert * roll * rotationRange, ref velocityZ, smoothTime)
    );
  }

  private void rotate(Transform t)
  {
    Vector3 euler = new Vector3(pitch, yaw, roll) * sensitive * Time.deltaTime * invert;
    t.Rotate(euler);
  }

  void FixedUpdate()
  {
    ForceMode mode = accelerate ? ForceMode.Acceleration : ForceMode.Force;
    rb.AddForce(transform.forward * cruiser * moving, mode);
  }

  private float clamp(float r, float max)
  {
    return Mathf.Clamp(invert * r * sensitive * Time.deltaTime, -max, max);
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

  void OnReset()
  {
    transform.position = initP;
    transform.rotation = initR;
  }

  void OnInvert()
  {
    invert = -invert;
  }

  void OnMove()
  {
    moving = moving == 0 ? 1 : 0;
  }
}
