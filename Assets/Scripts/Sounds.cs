using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attackSound, loseSound, enemyDieSound, flySound;



    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);

    }

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseSound);

    }
    public void PlayEnemyDieSound()
    {
        audioSource.PlayOneShot(enemyDieSound);

    }

    public void PlayFlySound()
    {
        audioSource.PlayOneShot(flySound);
    }

}
