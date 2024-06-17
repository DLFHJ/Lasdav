using UnityEngine;

public class PongBallController : MonoBehaviour
{
    private Rigidbody rb;
    public float forceMultiplier = 1.0f;
    public float maxVelocity = 10f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(0, -100, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 dir = collision.contacts[0].point - transform.position;
        dir = -dir.normalized;

        float forceMagnitude = 10f; // Adjust this value as needed
        rb.AddForce(dir * forceMagnitude, ForceMode.Impulse);
    }

   
}
