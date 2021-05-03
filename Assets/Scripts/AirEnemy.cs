using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
     float _speed = 2f;
    [SerializeField] Transform _point;




    void Update()
    {


        transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trashcan")
            Destroy(gameObject);
    }

}