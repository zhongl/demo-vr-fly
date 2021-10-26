using UnityEngine;

public class FlyController : MonoBehaviour
{
  public float forwardSpeed = 5f;
  public float turnSpeed = 5f;

  void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    float up = -v * turnSpeed * Time.deltaTime;
    float right = h * turnSpeed * Time.deltaTime;
    transform.Rotate(up, right, 0f);

    float f = Input.GetAxis("Jump");
    transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime * f);
  }

}
