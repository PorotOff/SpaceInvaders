using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private Rigidbody2D monster;

    [SerializeField] private float fallingSpeed = 5f;

    private void Start()
    {
        monster = GetComponent<Rigidbody2D>();
        monster.AddForce(Vector2.down * fallingSpeed, ForceMode2D.Impulse);
    }
}
