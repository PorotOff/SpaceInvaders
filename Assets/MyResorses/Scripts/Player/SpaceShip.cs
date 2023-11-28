using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private int healthPoint = 3;
    [SerializeField] private float spaceShipFlightSpeed = 2.5f;
    [SerializeField] private float spaceShipWeight = 10f;
    public int HealthPoint
    {
        get { return healthPoint; }
        private set
        {
            if(healthPoint - value < 0)
            {
                healthPoint = 0;
            }
            else
            {
                healthPoint = value;
            }
        }
    }
    public float SpaceShipFlightSpeed
    {
        get { return spaceShipFlightSpeed; }
        private set { spaceShipFlightSpeed = value; }
    }
    public float SpaceShipWeight
    {
        get { return spaceShipWeight; }
        private set {  spaceShipWeight = value; }
    }

    public void ReceiveDamage(int damage)
    {
        HealthPoint -= damage;
    }
}
