using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private AudioClip pointSound;

    private AudioSource _pointSource;
    
    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();

    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player"))
        {
            _gameController.AddPoint();
            
            var go = new GameObject();
            _pointSource = go.AddComponent<AudioSource>();
            _pointSource.clip = pointSound;
            _pointSource.volume = 0.5f;
            _pointSource.Play();

            Destroy(this.gameObject);
            
            Destroy(go, 2);
            
            
        }
    }
}
