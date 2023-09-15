using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public event EventHandler LavaTouchedEvent;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Run into Lava");
            LavaTouchedEvent?.Invoke(this,EventArgs.Empty);
            //TODO: Add gameOver Scene
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
