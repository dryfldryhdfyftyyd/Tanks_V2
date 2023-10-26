using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifetime = 3;

    public int maxDamage = 5;
    public int minDamage = 1;

    private void Start()
    {
        Destroy(gameObject, lifetime);
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

        //TODO: explode
        Destroy(gameObject);
    }
}
