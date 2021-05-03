using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{


   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
        if (collision.gameObject.tag == "Lava")
            Destroy(gameObject);
        
            


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Weapon")
            StartCoroutine(Death());
        if (collision.gameObject.tag == "Trashcan")
            Destroy(gameObject);

    }
 
    public IEnumerator Death()
    {
        GetComponent<Animator>().SetBool("Die", true);
        GetComponent<BoxCollider2D>().enabled = false;
        Player.RecountScore();
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

}