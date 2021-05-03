using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  [SerializeField] Text _text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = Player.GetScore().ToString();

    }
}
