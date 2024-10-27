using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Audio Clips", fileName = "AudioClips")]
public class AudioClipsSO : ScriptableObject {
    private static AudioClipsSO s_instance;
    public static AudioClipsSO instance {
        get {
            if (s_instance == null) {
                s_instance = Resources.Load<AudioClipsSO>("AudioClips");
            }
            return s_instance;
        }
    }

    public static AudioClip GetClip(AudioClipName name) {
        return instance.clips[(int)name];
    }


    private AudioClip[] clips;

    private void OnEnable() {
        clips = Resources.LoadAll<AudioClip>("Audios");
    }

}
