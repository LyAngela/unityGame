using UnityEngine;

public class CollisionableObject : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private CollisionableObjectType _objectType;

    public CollisionableObjectType ObjectType => _objectType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var go = new GameObject();
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = collisionSound;
            audioSource.volume = 0.5f;
            audioSource.Play();
            Destroy(go, 2);
        }
    }
}
