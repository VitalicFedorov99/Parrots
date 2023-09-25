using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamers : MonoBehaviour, IService
{
    public Transform target;           // ÷ель, за которой следует камера.
    public float smoothSpeed = 5.0f;   // —корость плавной смены положени€ камеры.

    private Vector3 offset;            // ќтступ между камерой и целью.

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
        // ¬ычисл€ем позицию, в которой должна находитьс€ камера.
        Vector3 desiredPosition = target.position + offset;

        // ѕлавно смещаем позицию камеры к желаемой позиции.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // ”станавливаем новую позицию камеры.
        transform.position = smoothedPosition;
    }
}
