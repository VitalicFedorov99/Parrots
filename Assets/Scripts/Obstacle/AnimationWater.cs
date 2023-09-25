using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWater : MonoBehaviour
{
    public Material material;  // ��������� ���� �������� � ����� ��������.
    public Vector2 vectorMove;
    public float speed;
    private void Start()
    {
        vectorMove=material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        vectorMove.y -= speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", vectorMove);
    }
}
