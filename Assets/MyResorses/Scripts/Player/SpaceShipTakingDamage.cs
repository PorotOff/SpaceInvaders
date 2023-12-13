using System;
using UnityEngine;

public class SpaceShipTakingDamage : MonoBehaviour
{
    private SpaceShip spaceShip;

    [SerializeField] private int defaultDamage = 1;
    [SerializeField] private int damageFromAttackedBase = 2;

    public static event Action OnSpaceShipTakedDamage;
    public static event Action OnSpaceShipZeroHearts;

    private void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
    }

    private void OnEnable()
    {
        MonsterDie.OnBaseAttacked += () => ReceiveDamageAndSendMessage(damageFromAttackedBase, OnSpaceShipTakedDamage);
    }
    private void OnDisable()
    {
        MonsterDie.OnBaseAttacked -= () => ReceiveDamageAndSendMessage(damageFromAttackedBase, OnSpaceShipTakedDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            ReceiveDamageAndSendMessage(defaultDamage, OnSpaceShipTakedDamage);
        }
    }

    private void ReceiveDamageAndSendMessage(int damage, Action message)
    {
        spaceShip.ReceiveDamage(damage);

        if (spaceShip.HealthPoint == 0)
        {
            OnSpaceShipZeroHearts?.Invoke();
        }

        message?.Invoke();
    }
}
