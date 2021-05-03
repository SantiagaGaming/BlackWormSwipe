using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform continueTr;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject continueScreen;
    [SerializeField] GameObject continueCleaner;
    [SerializeField] GameObject adScreen;
    private bool _isContunued = false;

  public void AD() {
        continueScreen.SetActive(true);
        adScreen.SetActive(false);

    }

    public void Continue()
    {
        _isContunued = true;
        player.GetComponent<Collider2D>().enabled = true;
        Player.ContinueGame();
        player.transform.position = new Vector3(player.transform.position.x, continueTr.transform.position.y , player.transform.position.z);
        LoseScreen.SetActive(false);
        StartCoroutine(ContinueCleanerCo());
        if (_isContunued) {
            continueScreen.SetActive(false);
        }
        IEnumerator ContinueCleanerCo() {
            continueCleaner.SetActive(true);
            yield return new WaitForSeconds(1f);
            continueCleaner.SetActive(false);
        }
       
    }
}
