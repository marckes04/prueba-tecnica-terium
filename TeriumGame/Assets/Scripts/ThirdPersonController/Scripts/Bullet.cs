using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    public float speed = 10f; // Adjust this value to control bullet speed

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        Destroy(gameObject, life);
    }

    private void FixedUpdate()
    {
        // Move the bullet forward in its local space
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthPlayer.Instance.TakeDamage(life);
        }
    }
}
