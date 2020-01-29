using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GameObject topPanel;
    public GameObject bottomPanel;

    private void OnEnable()
    {
        SpaceshipEventsBroker.Die += Hide;
    }

    private void Hide()
    {
        topPanel.GetComponent<Animator>().SetBool("PlayHideAnimation", true);
        bottomPanel.GetComponent<Animator>().SetBool("PlayHideAnimation", true);
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.Die -= Hide;
    }
}
