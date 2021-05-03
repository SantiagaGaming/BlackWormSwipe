using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    private float _speed = 0.5f;
    private float _timeSpeed = 0;

    void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
        _timeSpeed++;
       
        TimeSpeed();
    }
    private void TimeSpeed() {
        if (_timeSpeed == 3600) {
            _speed += 0.3f;
           
        }
        if (_timeSpeed == 7200)
        {
            _speed += 0.3f;
            FlyingEnemySpawn._timeShoot = 15;
            SideEnemySpawn._timeShoot = 12;
            
        }
        if (_timeSpeed == 10800)
        {
            _speed += 0.3f;
            FlyingEnemySpawn._timeShoot = 10;
            SideEnemySpawn._timeShoot = 10;


        }
        if (_timeSpeed == 15000)
        {
            _speed += 0.3f;
            FlyingEnemySpawn._timeShoot = 6;
            SideEnemySpawn._timeShoot = 8;

        }
    }


}
