using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip buttonSound;
    public AudioClip keySound;
    public AudioClip wrongKeySound;
    public AudioClip winSound;

    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSound()
    {
        source.PlayOneShot(buttonSound);
    }

    public void PlayKeySound()
    {
        source.PlayOneShot(keySound);
    }

    public void PlayWrongKeySound()
    {
        source.PlayOneShot(wrongKeySound);
    }

    public void PlayWinSound()
    {
        source.PlayOneShot(winSound);
    }
}
