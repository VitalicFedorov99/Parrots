using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{

    [SerializeField] private ServiceLocaterLoaderGame serviceLocater;

    

    private void Start()
    {
        ObjectPool.instance.InitPool();
        serviceLocater.RegisterServices();
        serviceLocater.Setup();
    }
}
