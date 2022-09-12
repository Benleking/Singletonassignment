using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotatingObject : MonoBehaviour
{
   // [SerializeField] private GameObject _thisOne;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _turnForward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_turnForward)
        {
            transform.RotateAround(this.transform.position, Vector3.forward, _rotationSpeed * Time.deltaTime);
        } else
        {
            transform.RotateAround(this.transform.position, Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }
}

  

