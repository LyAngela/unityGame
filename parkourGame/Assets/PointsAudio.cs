using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAudio : MonoBehaviour
{
    [SerializeField] private AudioClip pointSound;

    private AudioSource _pointSource;

    private Point _point;
    // Start is called before the first frame update
    void Start()
    {
        _pointSource = gameObject.AddComponent<AudioSource>();
        _pointSource.clip = pointSound;
        _pointSource.volume = 0.5f;

        _point = FindObjectOfType<Point>(true);
        _point.PointEvent += CatchPoint;

    }

    private void CatchPoint(object sender, EventArgs e)
    {
        _pointSource.Play();
    }
    
    

 
}
