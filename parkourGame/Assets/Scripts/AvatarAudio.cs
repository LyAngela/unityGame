using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAudio : MonoBehaviour
{

    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private AudioClip highBounceSound;
    
    private AudioSource _bounceSource;
    private AudioSource _highBounceSource;

    private Avatar _avatar;
    
    // Needed for consistent sound bouncing
    private bool _hasPlayedBounceSound = false;
    private bool _hasPlayedHighBounceSound = false;
    private CameraFollow _cameraFollow;
    private bool _soundStart = false;


    // Start is called before the first frame update
    void Start()
    {
        _bounceSource = gameObject.AddComponent<AudioSource>();
        _bounceSource.clip = bounceSound;
        _bounceSource.volume = 0.5f;

        
        _highBounceSource = gameObject.AddComponent<AudioSource>();
        _highBounceSource.clip = highBounceSound;
        _highBounceSource.volume = 0.5f;


        _avatar = FindObjectOfType<Avatar>(true);
        
        _cameraFollow = FindObjectOfType<CameraFollow>();
        _cameraFollow.OnFlyOverAnimationStop += (_,_) => _soundStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_soundStart)
        {
            if (_avatar.OnFloor && !_hasPlayedBounceSound)
            {
                _bounceSource.Play();
                _hasPlayedBounceSound = true;
            }
            else if (!_avatar.OnFloor)
            {
                _hasPlayedBounceSound = false;
            }
        
            if (_avatar.IsHighJumping && !_hasPlayedHighBounceSound)
            {
                _highBounceSource.Play();
                _hasPlayedHighBounceSound = true;
            }
            else if (!_avatar.IsHighJumping)
            {
                _hasPlayedHighBounceSound = false; 
            }
        }
      
    }
    
}
