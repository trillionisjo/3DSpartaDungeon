using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Audio Clips", fileName = "AudioClips")]
public class AudioClipsSO : ScriptableObject {
    private static AudioClipsSO _instance;
    public static AudioClipsSO instance {
        get {
            if (_instance == null) {
                _instance = Resources.Load<AudioClipsSO>("AudioClips");
            }
            return _instance;
        }
    }

    public static AudioClip GetClip(AudioFileName name) {
        return instance.clips[(int)name];
    }


    private AudioClip[] clips;

    private void OnEnable() {
        clips = Resources.LoadAll<AudioClip>("Audios");
    }

}
