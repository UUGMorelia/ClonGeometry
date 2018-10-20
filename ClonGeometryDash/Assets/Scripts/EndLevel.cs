using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            //Mostrar pantalla principal UI
            GameManager.Instance.GameOverUI();
        }
    }
}
