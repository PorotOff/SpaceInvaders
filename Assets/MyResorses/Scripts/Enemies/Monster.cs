using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    public static event Action OnMonsterDie;

    [SerializeField] private float speed = 2.5f;

    [Header ("Damage settings")]
    [SerializeField] private int defaultDamage = 1;
    [SerializeField] private int toPlayerBaseDamage = 2;

    [SerializeField] private int scoreForMonster = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpaceShip spaceShip = collision.gameObject.GetComponent<SpaceShip>();

        if (spaceShip != null)
        {
            spaceShip.ReceiveDamage(defaultDamage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomBoundary")
        {
            //TakeDamage();
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnMonsterDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
