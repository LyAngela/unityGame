using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip powerUpSound;

    private AudioSource _powerUpSource;
    
    public event EventHandler PowerUpEvent;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            var go = new GameObject();
            _powerUpSource = go.AddComponent<AudioSource>();
            _powerUpSource.clip = powerUpSound;
            _powerUpSource.volume = 0.5f;
            _powerUpSource.Play();
            
            PowerUpEvent?.Invoke(this, EventArgs.Empty);
            
            Destroy(this.gameObject);
            
            Destroy(go, 2);
        }
    }
}
