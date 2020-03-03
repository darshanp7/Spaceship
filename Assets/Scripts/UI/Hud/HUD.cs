using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GameObject topPanel;
    public GameObject bottomPanel;
    private static readonly int PlayHideAnimation = Animator.StringToHash("PlayHideAnimation");

    private void OnEnable()
    {
        SpaceshipEventsBroker.Die += Hide;
        GameControllerEventsBroker.LevelEnded += Hide;
    }

    private void Hide()
    {
        Debug.Log("Playing Hiding Animation");
        topPanel.GetComponent<Animator>().SetBool(PlayHideAnimation, true);
        bottomPanel.GetComponent<Animator>().SetBool(PlayHideAnimation, true);
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.Die -= Hide;
        GameControllerEventsBroker.LevelEnded -= Hide;
    }
}
