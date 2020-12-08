using UnityEngine;

public class AudioEmbiance : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    private int index;

    private void Start()
    {
        index = 0;
        // choisi la music a jouer
        audioSource.clip = playlist[index];

        // jouer la music
        audioSource.Play();
    }

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            index = (index + 1) % playlist.Length;
            audioSource.clip = playlist[index];
            audioSource.Play();
        }
    }
}
