using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCOpponent : MonoBehaviour
{
    PongBall ball;
    Vector3 ballPosition;
    Rigidbody2D rb;
    [SerializeField] float minSpeed = 0.5f;
    [SerializeField] float maxSpeed = 5f;
    float speed = 5f;

    void Start() {
        ball = FindObjectOfType<PongBall>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (ball == null) {
            ball = GameObject.FindObjectOfType<PongBall>();
        }
    }

    void FixedUpdate() {
        speed = Random.Range(minSpeed, maxSpeed);
        if (ball != null){
            ballPosition = ball.transform.position;

            rb.transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, ballPosition.y, 0),
            Time.fixedDeltaTime * speed);
        }
    }
}
