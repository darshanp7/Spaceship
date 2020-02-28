using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    private void OnEnable()
    {
        SpaceshipEventsBroker.FireWeapon += ChangeValue;
    }

    private void ChangeValue(float valueToBeChanged)
    {
        this.gameObject.GetComponent<UIBarScript>().NewValue += valueToBeChanged;
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.FireWeapon -= ChangeValue;
    }
}
