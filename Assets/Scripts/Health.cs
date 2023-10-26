using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealt = 100;

    public UnityEvent<int, int> onDamage;
    public UnityEvent<int, int> onHeal;
    public UnityEvent onDeath;

    int hp;

    private void Start()
    {
        hp = maxHealt;
    }

    public void Heal(int health)
    {
        hp += health;
        hp = hp > maxHealt ? maxHealt : hp;
        onHeal.Invoke(hp, health);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        hp = hp < 0 ? 0 : hp;
        onDamage.Invoke(hp, damage);

        if(hp <= 0)
        {
            onDeath.Invoke();
            Destroy(this);
        }

    }
}
