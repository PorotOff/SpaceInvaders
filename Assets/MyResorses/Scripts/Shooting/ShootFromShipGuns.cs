using System.Collections.Generic;
using UnityEngine;

public class ShootFromShipGuns : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<Transform> gunPoints;
    [SerializeField] private Transform bulletsContainer;

    private void Start()
    {
        bulletsContainer = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // �������� ��������� ����� �� ������
        Transform gunPoint = gunPoints[Random.Range(0, gunPoints.Count)];

        // ������� ���� �� ������� ��������� �����
        Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation, bulletsContainer);
    }
}
