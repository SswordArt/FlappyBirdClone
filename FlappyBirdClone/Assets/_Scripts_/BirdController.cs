using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{

    [SerializeField]private float _velocity = 1.5f;
    [SerializeField] private float _rotationspeed = 8f;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BirdFly();
    }

    private void BirdFly()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rigidbody.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, _rigidbody.linearVelocity.y *  _rotationspeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Reward")) GameManager.instance.CollectPoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.EndGameScreen();
    }
}
