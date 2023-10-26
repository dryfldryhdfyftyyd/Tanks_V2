using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionVfx;

    public float speed = 20;
    public float lifetime = 3;

    public int maxDamage = 5;
    public int minDamage = 1;

    private void Start()
    {
        Invoke(nameof(explosionVfx), lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();

        if(health != null)
        {
            var damage = Random.Range(minDamage, maxDamage);
            health.TakeDamage(damage);
        }

        Explode();
    }

    void Explode()
    {
        Instantiate(explosionVfx, transform.position, Quaternion.identity);//Quaternion.identity = explosionVfx.transform.rotation
        Destroy(gameObject);
    }
}
