using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private SpaceShip spaceShip;

    [SerializeField] private GameObject heartPrefab;

    private Transform heartsContainer;

    private void Start()
    {
        heartsContainer = GetComponent<Transform>();

        for (int i = 0; i < spaceShip.Health; i++)
        {
            Instantiate(heartPrefab, heartsContainer);
        }
    }

    private void OnEnable()
    {
        SpaceShip.OnSpaceShipDamaged += TurnOffHearts;
    }
    private void OnDisable()
    {
        SpaceShip.OnSpaceShipDamaged -= TurnOffHearts;
    }

    private void TurnOffHearts(int heartsCount)
    {
        for (int i = 0; i <= heartsCount; i++)
        {
            if (heartsContainer.childCount > 0)
            {
                Transform firstChild = heartsContainer.GetChild(0);
                Destroy(firstChild.gameObject);
            }
        }
    }
}
