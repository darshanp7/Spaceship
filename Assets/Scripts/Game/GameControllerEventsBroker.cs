using System;
using UnityEngine;

public class GameControllerEventsBroker : MonoBehaviour
{
    public static event Action LevelEnded;

    public static void CallLevelEnded()
    {
        LevelEnded?.Invoke();
    }
}
