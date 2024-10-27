using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Global Data", fileName = "Global")]
public class GlobalSO : MonoBehaviour {
    private static GlobalSO _instance;

    public static GlobalSO instance {
        get {
            if (_instance == null) {
                _instance = Resources.Load<GlobalSO>("Global");
            }
            return _instance;
        }
    }

    public static Player player {
        get => instance._player;
        set => instance._player = value;
    }


    [SerializeField] private Player _player;
}
