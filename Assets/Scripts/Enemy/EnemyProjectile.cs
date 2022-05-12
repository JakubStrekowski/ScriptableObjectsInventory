using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private readonly float LIFETIME = 5f;
    private readonly float SPEED = 6f;

    [SerializeField]
    Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * SPEED;
        StartCoroutine(nameof(DestroyAfterSeconds));
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(LIFETIME);
        Destroy(gameObject);
    }
}
