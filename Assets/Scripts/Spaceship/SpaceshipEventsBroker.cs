using System;

public class SpaceshipEventsBroker
{
    public static event Action<float> HitByAsteroid;
    public static event Action<string> CaughtCollectectibles;
    public static event Action Die;
    public static event Action<float> FireWeapon;
    public static event Action PushedBack;

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

    public static void CallPushBack()
    {
        if (PushedBack != null)
            PushedBack();
    }

    public static void CallCaughtCollectibles(string collectibleTag)
    {
        if(CaughtCollectectibles != null)
        {
            CaughtCollectectibles(collectibleTag);
        }
    }
}
