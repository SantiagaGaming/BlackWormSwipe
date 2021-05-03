using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _leftBlock;
    [SerializeField] private GameObject _rightBlock;
    [SerializeField] private Transform _spawnSpot1;
    [SerializeField] private Transform _spawnSpot2;
    [SerializeField] private float _timeShoot = 6f;
    private int _rnd;

    void Start()
    {
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_timeShoot);
        _rnd = Random.Range(0, 2);
        if (_rnd == 0)
        {
            Instantiate(_leftBlock, _spawnSpot1.transform.position, transform.rotation);
        }
        else if (_rnd == 1)
        {
            Instantiate(_rightBlock, _spawnSpot2.transform.position, transform.rotation);
        }

        StartCoroutine(Shooting());
    }
}