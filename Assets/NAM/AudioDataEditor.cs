using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioData)), CanEditMultipleObjects]
public class AudioDataEditor:Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        AudioData audioData = (AudioData)target;


        if (GUILayout.Button("⬇️ Load from folder"))
        {
            string path = Path.Combine(Application.dataPath, "NAM/AudioAssets");
            Debug.Log(path);
            var files = Directory.GetFiles(path).Where(s => (!s.Contains(".meta"))).ToArray();

            if (files.Length > 0)
            {
                foreach (var f in files)
                {


                    var ac = Resources.Load<AudioClip>(f);

                    if (ac!=null)
                    {
                        Debug.Log("Loaded audio from path: " + f);


                        if (audioData.GetAudioClip(f) == null)
                        {
                            audioData.audioList.Add(
                            new AudioFile(Path.GetFileName(f), ac)
                            );
                        }
                    }

                }
            }
        }



        SerializedProperty audioListProperty = serializedObject.FindProperty("audioList");
        EditorGUILayout.PropertyField(audioListProperty, true);

        serializedObject.ApplyModifiedProperties();

    }
}


