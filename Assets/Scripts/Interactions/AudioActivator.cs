using UnityEngine;

public class AudioActivator : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    // Llama a esta función para reproducir el audio
    public void PlayAudio()
    {
        if (audioSource == null || audioClip == null)
        {
            Debug.LogWarning("AudioActivator: Falta asignar el AudioSource o el AudioClip.");
            return;
        }

        // Si ya está sonando, lo reinicia
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
