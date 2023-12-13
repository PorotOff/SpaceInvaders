using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    private void Update()
    {
        if(transform.transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "SpaceShip")
        {
            Destroy(gameObject);
        }
    }
}
