using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ActionBasedForceFlyController : MonoBehaviour
{
  public float force = 2f;
  public ForceMode mode = ForceMode.Force;

  Vector3 turn;
  float forced;
  Rigidbody rb;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
      rb.AddForce(transform.forward * forced * force, mode);
  }

  void Update()
  {
    transform.Rotate(turn * Time.deltaTime);
  }

  void OnForce(InputValue value)
  {
      forced = value.Get<float>();
  }

  void OnTurn(InputValue value)
  {
    Vector2 tv = value.Get<Vector2>();
    turn = new Vector3(tv.y, tv.x, 0f);
  }
}
