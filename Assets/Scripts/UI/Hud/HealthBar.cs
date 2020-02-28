using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private void OnEnable()
    {
        SpaceshipEventsBroker.HitByAsteroid += ChangeValue;
    }

    private void ChangeValue(float valueToBeChanged)
    {
        this.gameObject.GetComponent<UIBarScript>().NewValue += valueToBeChanged;
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.HitByAsteroid -= ChangeValue;
    }
}
