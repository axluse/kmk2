using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {
    [SerializeField] private WindowSettings windowSettings;

    [HideInInspector] public GameObject windowObject;

    public Window () {
        windowObject = Instantiate(windowSettings.windowObject, windowSettings.position, Quaternion.identity);
    }
}

[CreateAssetMenu(menuName = "System/WindowSetting" )]
public class WindowSettings : ScriptableObject {
    public GameObject windowObject;
    public Vector3 position;
}