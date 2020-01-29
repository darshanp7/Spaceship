using System;

public class SpaceshipEventsBroker
{
    public static event Action<float> HitByAsteroid;
    public static event Action Die;
    public static event Action<float> FireWeapon;

    public static void CallDie()
    {
        if (Die != null)
            Die();
    }

    public static void CallHitByAsteroid(float damageAmount)
    {
        if (HitByAsteroid != null)
            HitByAsteroid(damageAmount);
    }

    public static void CallFireWeapon(float fuelAmount)
    {
        if (FireWeapon != null)
            FireWeapon(fuelAmount);
    }
}
