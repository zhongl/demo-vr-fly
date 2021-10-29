using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ActionBasedForceFlyController : MonoBehaviour
{
  public float sensitive = 4f;
  public float force = 3f;
  public float maxRotation = 15f;
  public ForceMode mode = ForceMode.Impulse;

  Vector2 turn;
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
    transform.Rotate(turnOrReset(turn.y, 0), 0f, turnOrReset(-turn.x, 0));
    // transform.Rotate(turnOrReset(turn.y, transform.rotation.x), 0f, turnOrReset(-turn.x, transform.rotation.z));
    transform.Translate(Vector3.forward * Time.deltaTime);
  }

  private float turnOrReset(float l, float r) {
    return l == 0 ? -r : Mathf.Clamp(l * sensitive * Time.deltaTime, -maxRotation, maxRotation);
  }
  void OnForce(InputValue value)
  {
    forced = value.Get<float>();
  }

  void OnTurn(InputValue value)
  {
    turn = value.Get<Vector2>();
  }
}
