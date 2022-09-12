using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theShootingthing : MonoBehaviour
{
    private bool _isShooting;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawnLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isShooting == false)
        {
            _isShooting = true;
            Instantiate(_bullet, _bulletSpawnLoc.transform.position, _bulletSpawnLoc.transform.rotation);
            StartCoroutine(shootingcooldown());
        }
    }
    IEnumerator shootingcooldown()
    {
        yield return new WaitForSeconds(0.5f);
        _isShooting = false;
    }
}
