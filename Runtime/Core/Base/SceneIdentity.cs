

using UnityEngine;

public class SceneIdentity : MonoBehaviour
{
    [SerializeField] private GameMode _gameModeOverride;

    public GameMode GetGameModeOverride => _gameModeOverride;
}
