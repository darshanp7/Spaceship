using System;
using UnityEngine;

public class GameControllerEventsBroker : MonoBehaviour
{
    public static event Action LevelEnded;

    public static void CallLevelEnded()
    {
        Debug.Log("Calling Level Ended Action");
        if (LevelEnded != null)
        {
            LevelEnded();
        }
    }
}
