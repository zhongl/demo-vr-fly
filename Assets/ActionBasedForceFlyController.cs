using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ActionBasedForceFlyController : MonoBehaviour
{
  public float sensitive = 4f;
  public float force = 3f;
  public float maxRotation = 15f;
  public ForceMode mode = ForceMode.Force;

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
    float x = turn.y * sensitive * Time.deltaTime; 
    float y = turn.x * sensitive * Time.deltaTime; 
    float z = Mathf.Clamp(-turn.x * sensitive * Time.deltaTime, -maxRotation, maxRotation); 
    transform.Rotate(x, y, z);
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
