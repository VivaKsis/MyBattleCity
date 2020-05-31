using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject explosionAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        DestroyBullet();

        Vector3 hitPosition = transform.position;
        IDamageable damageable = hitInfo.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(hitPosition);
        }
    }

    private void DestroyBullet ()
    {
        GameObject explosion = Instantiate(explosionAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 0.5f);
    }
}
