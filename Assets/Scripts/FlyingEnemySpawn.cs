using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _flyEnemy;
    [SerializeField] private Transform _spawnSpot;
     public static float _timeShoot = 20f;

    void Start()
    {
      
            StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_timeShoot);
        _spawnSpot.transform.position = new Vector3(Random.Range(-1.6f, 1.6f),transform.position.y , transform.position.z);
        Instantiate(_flyEnemy, _spawnSpot.transform.position, transform.localRotation = Quaternion.Euler(0, 0, 0));
        StartCoroutine(Shooting());
    }
}