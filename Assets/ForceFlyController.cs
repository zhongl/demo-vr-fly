using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceFlyController : MonoBehaviour
{
  public float force = 2f;
  public ForceMode mode = ForceMode.Force;

  Rigidbody rb;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    float f = Input.GetAxis("Jump");
    rb.AddForce(transform.forward * f * force, mode);
  }

}
