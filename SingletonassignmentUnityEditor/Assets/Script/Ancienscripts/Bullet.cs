using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _Speed = 10f;   // this is the projectile's speed
   // private float _Lifespan = 3f; // this is the projectile's lifespan (in seconds)


    void Start()
    {

    }
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * _Speed;
        Destroy(gameObject, 3f);
    }
}
