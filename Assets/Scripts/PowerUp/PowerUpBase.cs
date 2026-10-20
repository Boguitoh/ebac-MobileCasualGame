using UnityEngine;

public class PowerUpBase : CollectibleBase
{
    [Header("Power Up")]
    public float powerDuration;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), powerDuration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }
}
