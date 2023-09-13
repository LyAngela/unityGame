using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
  
    public event EventHandler PointEvent;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            PointEvent?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }
}
