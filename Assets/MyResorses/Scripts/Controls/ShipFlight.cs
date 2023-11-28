using UnityEngine;

public class ShipFlight : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D SpaceShip;

    private void Start()
    {
        SpaceShip = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            SpaceShip.AddForce(new Vector2(horizontalInput, verticalInput) * speed, ForceMode2D.Force);
        }
    }
}
