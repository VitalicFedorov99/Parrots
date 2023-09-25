using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerMovement
{
    public float speed = 5f;         // Скорость движения объекта.
    public float minHeight = 1f;     // Минимальная высота.
    public float maxHeight = 5f;     // Максимальная высота.
    public float hoverHeight = 3f;   // Высота "парения" (средняя высота).

    private float currentHeight;
    private float newHeight;
    private Vector3 newPosition;
    private GameObject bird;


    [SerializeField] private TypeHeight currentHeight1;


    

    public void Setup(GameObject birdVariant)
    {
        bird = birdVariant;
        newPosition = bird.transform.position;
        newPosition.y = hoverHeight;
        bird.transform.position = newPosition;
        currentHeight = hoverHeight;
        currentHeight1 = TypeHeight.Midding;
        newHeight = hoverHeight;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetupNewHeight(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetupNewHeight(false);
        }
        bird.transform.Translate(Vector3.back * speed * Time.deltaTime); 
        currentHeight = Mathf.MoveTowards(currentHeight, newHeight, Time.deltaTime);
        newPosition = bird.transform.position;
        newPosition.y = currentHeight;
        bird.transform.position = newPosition;
    }


    public void Fall() 
    {
        currentHeight = Mathf.Lerp(currentHeight, 0, Time.deltaTime);
        newPosition = bird.transform.position;
        newPosition.y = currentHeight;
        bird.transform.position = newPosition;
    }
    public void MoveUp(TypeHeight typeHeight)
    {
        switch (typeHeight)
        {
            case TypeHeight.Midding:
                newHeight = hoverHeight;
                currentHeight1 = TypeHeight.Midding;
                break;
            case TypeHeight.High:
                newHeight = maxHeight;
                currentHeight1 = TypeHeight.High;
                break;
        }

    }

    public void MoveDown(TypeHeight typeHeight)
    {
        switch (typeHeight)
        {
            case TypeHeight.Midding:
                newHeight = hoverHeight;
                currentHeight1 = TypeHeight.Midding;
                break;
            case TypeHeight.Low:
                newHeight = minHeight;
                currentHeight1 = TypeHeight.Low;
                break;
        }

    }

    private void SetupNewHeight(bool isUp)
    {
        if (isUp)
        {
            switch (currentHeight1)
            {
                case TypeHeight.High:
                    break;
                case TypeHeight.Midding:
                    MoveUp(TypeHeight.High);
                    break;
                case TypeHeight.Low:
                    MoveUp(TypeHeight.Midding);
                    break;
            }
        }
        else
        {
            switch (currentHeight1)
            {
                case TypeHeight.High:
                    MoveDown(TypeHeight.Midding);
                    break;
                case TypeHeight.Midding:
                    MoveDown(TypeHeight.Low);
                    break;
                case TypeHeight.Low:
                    break;
            }
        }

    }
}

public enum TypeHeight
{
    Low,
    Midding,
    High
}
