using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private AudioClip pointSound;

    private AudioSource _pointSource;
    
    public event EventHandler PointEvent;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            var go = new GameObject();
            _pointSource = go.AddComponent<AudioSource>();
            _pointSource.clip = pointSound;
            _pointSource.volume = 0.5f;
            _pointSource.Play();
            
            
            PointEvent?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
            
            Destroy(go, 2);
        }
    }
}
