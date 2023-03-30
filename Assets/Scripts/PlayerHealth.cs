using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDead;

    [SerializeField] int hp = 1;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            DeductHP();
    }

    void DeductHP()
    {
        hp--;
        if (hp <= 0)
            OnPlayerDead?.Invoke();
    }
}
