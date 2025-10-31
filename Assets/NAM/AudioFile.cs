using UnityEngine;

[System.Serializable]
public class AudioFile
{
    public AudioFile(string name, AudioClip audioClip)
    {
        this.name = name; 
        this.audioClip = audioClip;
    }

    public string name;
    public AudioClip audioClip;
}


