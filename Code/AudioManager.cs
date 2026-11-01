using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backGroudAudio;
    [SerializeField] private AudioSource soundEffectAudio;
    [SerializeField] private AudioClip backGroudSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip coinSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackGroundSound();
    }

 
    public void PlayBackGroundSound()
    {
        backGroudAudio.clip = backGroudSound;
        backGroudAudio.Play();
    }
    public void PlayJumpSound()
    {
        soundEffectAudio.PlayOneShot(jumpSound);
    }
    public void PlayCoinSound()
    {
        soundEffectAudio.PlayOneShot(coinSound);
    }
}
