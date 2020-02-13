using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwooshBackAnimation : MonoBehaviour
{

    private void OnEnable()
    {
        SpaceshipEventsBroker.PushedBack += PlaySwooshBackAnimation;
    }

    private void PlaySwooshBackAnimation()
    {
        this.GetComponent<Animator>().SetBool("PlayPushBackEffect", true);
    }

    private void OnSwooshBackEndEvent()
    {
        this.GetComponent<Animator>().SetBool("PlayPushBackEffect", false);
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.PushedBack -= PlaySwooshBackAnimation;
    }
}
