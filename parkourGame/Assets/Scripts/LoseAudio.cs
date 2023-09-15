

using System;
using UnityEngine;

public class LoseAudio : MonoBehaviour
{
    
    [SerializeField] private AudioClip loseSound;

    private AudioSource _loseSource;

    private Lava[] _lava;
    private Obstacle[] _obstacle;

    private void Start()
    {
        _loseSource = gameObject.AddComponent<AudioSource>();
        _loseSource.clip = loseSound;
        _loseSource.volume = 0.5f;

        _lava = GetComponentsInChildren<Lava>();
        _obstacle = GetComponentsInChildren<Obstacle>();

        foreach (var lava in _lava)
        {
            lava.LavaTouchedEvent += OnLostSound;
        } 
        foreach (var obstacle in _obstacle)
        {
            obstacle.ObstacleTouchedEvent += OnLostSound;
        }


    }

    private void OnLostSound(object sender, EventArgs e)
    {
        _loseSource.Play();
    }
}
