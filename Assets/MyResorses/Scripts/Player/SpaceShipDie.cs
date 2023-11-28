using System;
using UnityEngine;

public class SpaceShipDie : MonoBehaviour
{
    public static int playerHP = 5;

    [SerializeField] private Transform playerHearts;
    [SerializeField] private GameObject heartPrefab;

    private int defaultDamage = 1;

    public static event Action OnPlayerDie;
    public static event Action OnPlayerGettedDamage;

    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        for(int i = 0; i < playerHP; i++)
        {
            Instantiate(heartPrefab, playerHearts);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            GetDamage(defaultDamage);
        }
    }

    private void GetDamage(int damage)
    {
        playerHP -= damage;

        OnPlayerGettedDamage?.Invoke();

        HeartDestroy();
        GameOver();
    }
    private void GameOver()
    {
        if (playerHP <= 0)
        {
            Destroy(gameObject);

            OnPlayerDie?.Invoke();

            Time.timeScale = 0;

            gameOverPanel.SetActive(true);
        }
    }
    private void HeartDestroy()
    {
        Transform heart = playerHearts.transform.GetChild(0);
        Destroy(heart.gameObject);
    }
}
