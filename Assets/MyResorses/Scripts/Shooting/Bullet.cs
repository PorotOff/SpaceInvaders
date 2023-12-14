using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();

        if(monster != null)
        {
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
