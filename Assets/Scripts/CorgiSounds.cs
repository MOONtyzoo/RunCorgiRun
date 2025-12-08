using UnityEngine;
using UnityEngine.Audio;

public class CorgiSounds : MonoBehaviour
{
    [SerializeField] private Corgi corgi;

    [SerializeField] private AudioClip boneSound;
    [SerializeField] private AudioClip beerSound;
    [SerializeField] private AudioClip pillSound;
    [SerializeField] private AudioClip moonshineSound;
    
    private void Awake()
    {
        corgi.OnPickUp += OnPickUp;
    }
    
    private void OnPickUp(string pickupName)
    {
        if (pickupName == "Bone")
        {
            AudioSource.PlayClipAtPoint(boneSound, Vector3.zero);
        }
        else if (pickupName == "Pill")
        {
            AudioSource.PlayClipAtPoint(pillSound, Vector3.zero);
        }
        else if (pickupName == "Moonshine")
        {
            AudioSource.PlayClipAtPoint(moonshineSound, Vector3.zero);
        }
        else if (pickupName == "Beer")
        {
            AudioSource.PlayClipAtPoint(beerSound, Vector3.zero);
        }
    }
}
