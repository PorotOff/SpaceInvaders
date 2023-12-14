using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    private Rigidbody2D bullet;
    [SerializeField] private float startSpeed = 10f;

    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.AddForce(Vector2.up * startSpeed, ForceMode2D.Impulse);
    }
}
