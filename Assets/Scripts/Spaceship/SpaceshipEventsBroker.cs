using System;

public static class SpaceshipEventsBroker
{
    public static event Action<float> HitByAsteroid;
    public static event Action<string> CaughtCollectibles;
    public static event Action Die;
    public static event Action<float> FireWeapon;
    public static event Action PushedBack;

    public static void CallDie()
    {
        Die?.Invoke();
    }

    public static void CallHitByAsteroid(float damageAmount)
    {
        HitByAsteroid?.Invoke(damageAmount);
    }
    public static void CallFireWeapon(float fuelAmount)
    {
        FireWeapon?.Invoke(fuelAmount);
    }
    public static void CallPushBack()
    {
        PushedBack?.Invoke();
    }
    public static void CallCaughtCollectibles(string collectibleTag)
    {
        CaughtCollectibles?.Invoke(collectibleTag);
    }
}
