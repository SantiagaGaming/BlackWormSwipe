using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _platform;
    [SerializeField] private Transform _spawnSpot;
    [SerializeField] private float _timeShoot = 6f;
    private int _rnd;

    void Start()
    {
      
            StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {

        yield return new WaitForSeconds(_timeShoot);
        _spawnSpot.transform.position = new Vector3(Random.Range(-1.1f, 1.3f),transform.position.y , transform.position.z);
        _rnd = Random.Range(0, _platform.Length);
        Instantiate(_platform[_rnd], _spawnSpot.transform.position, transform.rotation);
        StartCoroutine(Shooting());
    }
}