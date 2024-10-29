using UnityEngine;

public static class Audio {
    private static AudioClip[] audioClips;

    public static void LoadAudioClips() {
        audioClips = Resources.LoadAll<AudioClip>("Audios");
    }

    public static AudioClip GetAudioClip(AudioClipName name) {
        if (audioClips == null) {
            return null;
        }
        return audioClips[(int)name];
    }
}
