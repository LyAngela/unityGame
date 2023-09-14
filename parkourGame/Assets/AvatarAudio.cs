using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAudio : MonoBehaviour
{

    [SerializeField] private AudioClip bounceSound;

    private AudioSource _bounceSource;

    private Avatar _avatar;
    // Start is called before the first frame update
    void Start()
    {
        _bounceSource = gameObject.AddComponent<AudioSource>();
        _bounceSource.clip = bounceSound;
        _bounceSource.loop = false;
        _bounceSource.volume = 0.5f;
        _bounceSource.Play();
        _bounceSource.Pause();

        _avatar = FindObjectOfType<Avatar>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_avatar.GetOnFloor())
        {
            _bounceSource.Play();
        }
        else
        {
            _bounceSource.UnPause();
        }
    }
}
