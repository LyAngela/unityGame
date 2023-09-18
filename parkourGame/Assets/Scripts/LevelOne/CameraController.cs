using System;
using UnityEngine;
using UnityEngine.Splines;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothTime = 1.5F;

    private readonly Vector3 _offset = new Vector3(0, 7, -10);
    private Vector3 velocity = Vector3.zero;
    private Avatar _avatar;
    public event EventHandler OnFlyOverAnimationStop;
    private SplineAnimate _splineAnimate;


    private void Start()
    {
        _avatar = FindObjectOfType<Avatar>();
        _splineAnimate = GetComponent<SplineAnimate>();
    }

    void FixedUpdate()
    {
        if (!_splineAnimate.IsPlaying && _splineAnimate)
        {
            OnFlyOverAnimationStop?.Invoke(this, null);
            Destroy(_splineAnimate);
        }

        if (_avatar != null)
        {
            // Define a target position above and behind the target transform
            var currentPos = transform.position;
            var targetPos = _avatar.transform.position + _avatar.transform.TransformDirection(_offset);

            transform.position = Vector3.SmoothDamp(currentPos, targetPos, ref velocity, smoothTime);

            transform.LookAt(_avatar.transform);
        }
    }
}