using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    public List<AudioFile> audioList = new List<AudioFile>() { };

 
    public AudioClip GetAudioClip(string name)
    {
        foreach(AudioFile file in audioList)
        {
            if(file.name == name)
                return file.audioClip;
        }

        return null;
    }

}


