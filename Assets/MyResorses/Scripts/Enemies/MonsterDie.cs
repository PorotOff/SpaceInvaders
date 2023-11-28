using System;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    [SerializeField] private int monsterHP = 1;
    [SerializeField] private int scoreForMonster = 100;

    private int damage = 1;

    public static event Action<int> OnMonsterDie;
    public static event Action OnBaseAttacked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            monsterHP -= damage;

            if(monsterHP <= 0)
            {
                Destroy(gameObject);
                OnMonsterDie?.Invoke(scoreForMonster);
            }
        }
    }

    private void Update()
    {
        if(gameObject.transform.position.y <= -10)
        {
            Destroy(gameObject);
            OnBaseAttacked?.Invoke();
        }
    }
}
