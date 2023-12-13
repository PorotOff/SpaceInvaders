using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float health = 1f;

    [SerializeField] private float speed = 2.5f;

    [Header ("Damage settings")]
    [SerializeField] private int defaultDamage = 1;
    [SerializeField] private int toPlayerBaseDamage = 2;

    private void DoDamage(SpaceShip spaceShip)
    {
        spaceShip.ReceiveDamage(defaultDamage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpaceShip spaceShip = collision.gameObject.GetComponent<SpaceShip>();

        if (spaceShip != null)
        {
            DoDamage(spaceShip);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomBoundary")
        {
            //DoDamage();
        }
    }
}
