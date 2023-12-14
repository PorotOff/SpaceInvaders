using System;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private int health = 3;
    public int Health
    {
        get { return health; }
    }

    [SerializeField] private float speed = 10f;
    public float Speed
    {
        get { return speed; }
    }

    public static event Action OnSpaceShipDied;
    public static event Action<int> OnSpaceShipDamaged;

    public void TakeDamge(int damage)
    {
        health -= damage;

        OnSpaceShipDamaged(damage);

        if (health <= 0)
        {
            OnSpaceShipDied?.Invoke();
        }
    }
}
