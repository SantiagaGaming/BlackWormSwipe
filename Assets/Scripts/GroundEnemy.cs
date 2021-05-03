using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy: MonoBehaviour
{
    public float speed = 1.5f;
    public bool moveLeft = true;
    [SerializeField]  private Transform _groundDetect;
    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetect.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }
        }
    }
}