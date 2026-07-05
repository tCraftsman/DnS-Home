using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public GameConfigs configs;

    void Awake() {
        Instance = this;
    }
}
