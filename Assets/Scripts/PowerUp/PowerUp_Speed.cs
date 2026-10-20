using UnityEngine;

public class PowerUp_Speed : PowerUpBase
{
    [Header("Speed Up")]
    public float increasedSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.PowerUp_Speed(increasedSpeed);
        PlayerController.instance.SetPowerUpText("Speed up");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetSpeed();
        PlayerController.instance.SetPowerUpText("");
    }
}
