using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float health = 1f;

    [SerializeField] private float speed = 2.5f;
    public float Speed
    {
        get { return speed; }
    }

    [Header ("Damage settings")]
    [SerializeField] private int defaultDamage = 1;

    [SerializeField] private int scoreForMonster = 100;

    public static event Action<int> OnMonsterDie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpaceShip spaceShip = collision.gameObject.GetComponent<SpaceShip>();

        if (spaceShip != null)
        {
            spaceShip.TakeDamge(defaultDamage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BottomBoundary")
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnMonsterDie?.Invoke(scoreForMonster);
            Destroy(gameObject);
        }
    }
}
