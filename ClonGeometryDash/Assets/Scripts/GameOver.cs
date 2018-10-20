using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            obj.gameObject.SetActive(false);
            GameManager.Instance.GameOverUI();
        }
    }
}
