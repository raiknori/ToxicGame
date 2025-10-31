using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager:MonoBehaviour
{
    [SerializeField] AudioData audioData;
    [SerializeField] AudioSource audioSource;
    public static AudioManager Instance
    {
        get;

        private set;
    }

    private void OnValidate()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(string audioName, bool randomPitched = false)
    {
        var audioClip = GetAudioClip(audioName);


        if (audioClip != null)
        {
            if(randomPitched)
            {
                audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f); 
                audioSource.PlayOneShot(audioClip);
                audioSource.pitch = 1;
                return;
            }

            audioSource.PlayOneShot(audioClip);
        }
    }
    


    AudioClip GetAudioClip(string name)
    {
        return audioData.GetAudioClip(name);
    }
}


