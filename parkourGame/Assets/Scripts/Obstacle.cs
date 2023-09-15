using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
 
    public event EventHandler ObstacleTouchedEvent;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            ObstacleTouchedEvent?.Invoke(this,EventArgs.Empty);
            //TODO: Add gameOver Scene
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
