using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Sound Manager", fileName = "SoundManager")]
public class SoundManagerSO : ScriptableObject {
    private static SoundManagerSO _instance;
    public static SoundManagerSO instance {
        get {
            if (_instance == null) {
                _instance = Resources.Load<SoundManagerSO>("SoundManager");
            }
            return _instance;
        }
    }

    [SerializeField] private AudioSource soundObject;

    public static void PlaySoundFxClip(AudioClip clip, Vector3 soundPos, float volume) {
        AudioSource a = Instantiate(instance.soundObject, soundPos, Quaternion.identity);
        a.clip = clip;
        a.volume = volume;
        a.Play();
    }
}
