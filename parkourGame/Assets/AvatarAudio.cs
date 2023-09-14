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
    private bool hasPlayedBounceSound = false;
    private bool hasPlayedHighBounceSound = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _bounceSource = gameObject.AddComponent<AudioSource>();
        _bounceSource.clip = bounceSound;
        _bounceSource.loop = false;
        _bounceSource.volume = 0.5f;
        _bounceSource.Play();
        _bounceSource.Pause(); 
        
        _highBounceSource = gameObject.AddComponent<AudioSource>();
        _highBounceSource.clip = highBounceSound;
        _highBounceSource.loop = false;
        _highBounceSource.volume = 0.5f;
        _highBounceSource.Play();
        _highBounceSource.Pause();

        _avatar = FindObjectOfType<Avatar>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_avatar.OnFloor && !hasPlayedBounceSound)
        {
            _bounceSource.Play();
            hasPlayedBounceSound = true;
        }
        else if (!_avatar.OnFloor)
        {
            hasPlayedBounceSound = false; // Reset the flag if not on the floor
        }
        
        if (_avatar.IsHighJumping && !hasPlayedHighBounceSound)
        {
            _highBounceSource.Play();
            hasPlayedHighBounceSound = true;
        }
        else if (!_avatar.IsHighJumping)
        {
            hasPlayedHighBounceSound = false; // Reset the flag if not high jumping
        }
    }
    
}
