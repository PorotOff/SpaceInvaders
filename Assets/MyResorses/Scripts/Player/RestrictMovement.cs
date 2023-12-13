using UnityEngine;

public class RestrictMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    private Collider2D currentObjectCollider2D;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        currentObjectCollider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector2 currentObjectPosition = transform.position;

        float currentObjectWidth = currentObjectCollider2D.bounds.size.x / 2;
        float currentObjectHeight = currentObjectCollider2D.bounds.size.y / 2;

        currentObjectPosition.x = Mathf.Clamp(currentObjectPosition.x, screenBounds.x * -1 + currentObjectWidth, screenBounds.x - currentObjectWidth);
        currentObjectPosition.y = Mathf.Clamp(currentObjectPosition.y, screenBounds.y * -1 + currentObjectHeight, screenBounds.y - currentObjectHeight);

        transform.position = currentObjectPosition;
    }
}
