using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Vector2 knifespawn;
    [SerializeField]
    private GameObject knifePrefab;

    public void Start()
    {
        InvokeRepeating("SpawnKnife", 0, 1f); //SpawnKnife();
    }

    private void SpawnKnife()
    {
        
        Instantiate(knifePrefab, knifespawn , Quaternion.identity );
        
    }
}
