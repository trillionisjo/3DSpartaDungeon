using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Sound Manager", fileName = "SoundManager")]
public class SoundManagerSO : ScriptableObject {
    private static SoundManagerSO s_instance;

    public static SoundManagerSO instance {
        get {
            if (s_instance == null) {
                s_instance = Resources.Load<SoundManagerSO>("SoundManager");
            }
            return s_instance;
        }
    }

    public static void PlaySoundFxClip(AudioClip clip, Vector3 soundPos, float volume) {
        AudioSource a = Instantiate(instance.soundObject, soundPos, Quaternion.identity);
        a.clip = clip;
        a.volume = volume;
        a.Play();
    }

    [SerializeField] private AudioSource soundObject;
}
