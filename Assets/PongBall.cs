using UnityEngine;

public class PongBall : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementVector;
    public float speedMultiplier = 1.1f;
    public float maxSpeed = 20f;
    float speed = 5f;
    float force = 90f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        if (rb == null) {
            rb = GetComponent<Rigidbody2D>();
        }
        
        rb.linearVelocity = Vector2.zero;
        ThrowBall();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Opponent")) {
            rb.linearVelocity *= speedMultiplier;
            if (rb.linearVelocity.magnitude > maxSpeed) {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
        
    }

    private Vector2 GenerateRandomDirection() {
        float randomAngle;

        if (Random.value < 0.5f) {
            randomAngle = Random.Range(-45f, 45f);
        } 
        else {
            randomAngle = Random.Range(135f, 225f); 
        }

        float radians = randomAngle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }
    void ThrowBall() {
        rb.AddForce(GenerateRandomDirection()* speed * force);
    }
}
