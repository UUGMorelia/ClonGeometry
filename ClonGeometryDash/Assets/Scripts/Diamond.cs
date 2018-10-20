using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    public int valueDiamond = 1;

	void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Player.Instance.currentDiamonds += valueDiamond;
            GameManager.Instance.UpdateCurrentDiamonds(Player.Instance.currentDiamonds);
        }
    }
}
