using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SideEnemySpawn : MonoBehaviour
{
    [SerializeField]  private GameObject _enemy;
    [SerializeField] private Transform[] _spawnSpot;
    public static float _timeShoot = 17f;
    private int _rnd;
    void Start()
    {
   

        StartCoroutine(Shooting());
       
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_timeShoot);
        _rnd = Random.Range(0, _spawnSpot.Length);
        if (_rnd == 0)
        {
            Instantiate(_enemy, _spawnSpot[0].transform.position, transform.localRotation = Quaternion.Euler(0, 0, -90));
        }
        else if (_rnd == 1)
        {
            Instantiate(_enemy, _spawnSpot[1].transform.position, transform.localRotation = Quaternion.Euler(0, 0, 90));
        }

            StartCoroutine(Shooting());
        

    }
}