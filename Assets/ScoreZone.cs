using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    GameManager manager;
    
    private void Start() {
        manager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (tag == "PlayerZone") {
            manager.opponentWin.Invoke();
        }
        else if (tag == "OpponentZone") {
            manager.playerWin.Invoke();
        }
    }
}
