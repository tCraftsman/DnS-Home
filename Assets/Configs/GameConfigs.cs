using UnityEngine;

[CreateAssetMenu(fileName = "GameConfigs", menuName = "Game Configs")]
public class GameConfigs : ScriptableObject {
    public UnitType Units;
    public float MoveSensitivity;
    public float RotateSensitivity;
    public float MinDistance, MaxDistance, ZoomStep;
}
