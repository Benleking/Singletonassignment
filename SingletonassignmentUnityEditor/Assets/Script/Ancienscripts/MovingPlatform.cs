using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private Transform _pointA;
    [SerializeField]
    private Transform _pointB;
    private Transform _objective;
    // Start is called before the first frame update
    void Start()
    {
        _objective = _pointA;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _objective.position, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _objective.position) <= 0.2f)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        _objective = _objective.position != _pointA.position ? _pointA : _pointB;
    }
}
