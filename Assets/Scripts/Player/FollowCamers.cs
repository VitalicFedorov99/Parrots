using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamers : MonoBehaviour, IService
{
    public Transform target;           // ����, �� ������� ������� ������.
    public float smoothSpeed = 5.0f;   // �������� ������� ����� ��������� ������.

    private Vector3 offset;            // ������ ����� ������� � �����.

    [SerializeField] private bool isFall;
    public void Setup() 
    {
        offset = transform.position - target.position;
        isFall = true;
    }

    public void Setup(Transform startPos) 
    {
        transform.position = startPos.position;
        Setup();
    }

    public void SetIsFall(bool flag) 
    {
        isFall = flag;
    }


    private void LateUpdate()
    {
        if (!isFall)
            return;
        // ��������� �������, � ������� ������ ���������� ������.
        Vector3 desiredPosition = target.position + offset;

        // ������ ������� ������� ������ � �������� �������.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // ������������� ����� ������� ������.
        transform.position = smoothedPosition;
    }
}
