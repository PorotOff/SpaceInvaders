using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private Monster monster;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        monster = GetComponent<Monster>();
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.AddForce(Vector2.down * monster.Speed, ForceMode2D.Impulse);
    }
}
