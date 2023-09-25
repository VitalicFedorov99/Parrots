using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour, IPooledObject
{
    [SerializeField] private Animator animator;
    [SerializeField] private TMPro.TMP_Text textScore;
    
    private int score;

    public TypeObjectInPool TypeObject => TypeObjectInPool.Hoop;
    
    public void Setup(int score) 
    {
        this.score = score;
        textScore.text = score.ToString();
    }

    

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }

    public void Tween() 
    {
        
        animator.SetTrigger("Tween");
        ServiceLocator.Current.Get<ScoreManager>().AddScoreInLevel(score);
    }

  
}
