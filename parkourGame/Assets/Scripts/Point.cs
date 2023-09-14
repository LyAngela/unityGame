using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private AudioClip pointSound;

    private AudioSource _pointSource;

    void Start()
    {
        _pointSource = gameObject.AddComponent<AudioSource>();
        _pointSource.clip = pointSound;
        _pointSource.volume = 0.5f;

    }
    public event EventHandler PointEvent;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            _pointSource.Play();
            PointEvent?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }
}
