using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Camera : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Avatar _avatar;
    [SerializeField] private float smoothTime = 1.5F;
    private readonly Vector3 _offset = new Vector3(0,7, -10);
    private float _rotationSpeed;
    public event EventHandler OnFlyOverAnimationStop;
    private SplineAnimate _splineAnimate;


    private void Start()
    {
        _avatar = FindObjectOfType<Avatar>();
        _splineAnimate = GetComponent<SplineAnimate>();
    }

    void FixedUpdate()
    {

        if (!_splineAnimate.IsPlaying)
        {
            OnFlyOverAnimationStop?.Invoke(this,null);
        }
        
        // Define a target position above and behind the target transform
        var currentPos = transform.position;
        var targetPos = _avatar.transform.position + _avatar.transform.TransformDirection(_offset);

        transform.position = Vector3.SmoothDamp(currentPos, targetPos, ref velocity, smoothTime);
        
        transform.LookAt(_avatar.transform);
 
    }
    
}