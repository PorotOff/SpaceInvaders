using UnityEngine;

public class DisplayPlayerHearts : MonoBehaviour
{
    private SpaceShip spaceShip;

    [SerializeField] private Transform playerHearts;
    [SerializeField] private GameObject heartPrefab;

    private void Start()
    {
        spaceShip = GetComponent<SpaceShip>();

        DisplayHearts();
    }

    private void OnEnable()
    {
        SpaceShipTakingDamage.OnSpaceShipTakedDamage += DisplayHearts;
    }
    private void OnDisable()
    {
        SpaceShipTakingDamage.OnSpaceShipTakedDamage -= DisplayHearts;
    }

    private void DisplayHearts()
    {
        foreach(Transform heart in playerHearts)
        {
            Destroy(heart.GetChild(0));
        }

        for (int i = 0; i < spaceShip.HealthPoint; i++)
        {
            Debug.Log(spaceShip.HealthPoint);
            Instantiate(heartPrefab, playerHearts);
        }
    }
}
