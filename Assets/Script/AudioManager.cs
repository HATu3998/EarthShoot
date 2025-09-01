using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip enegryClip;
    public void playShootSound()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }
    public void playReloadSound()
    {
        effectAudioSource.PlayOneShot(reloadClip);
    }
    public void playEnergySound()
    {
        effectAudioSource.PlayOneShot(enegryClip);
    }
    public void playDefaultAudio()
    {
        bossAudioSource.Stop();

        defaultAudioSource.Play();
    }
    public void playBossAudio()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Play();
    }
    public void StopAudioGame()
    {
        effectAudioSource.Stop();
        defaultAudioSource.Stop();
        bossAudioSource.Stop();
    }
}
