using UnityEngine;

public class Flight : MonoBehaviour
{
    private SpaceShip spaceShip;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            rigidBody.AddForce(new Vector2(horizontalInput, verticalInput) * spaceShip.Speed, ForceMode2D.Force);
        }
    }
}
