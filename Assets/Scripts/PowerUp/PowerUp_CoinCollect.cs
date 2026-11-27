using UnityEngine;

public class PowerUp_CoinCollect : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 7;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.ChangeCoinCollectorSize(sizeAmount);
        PlayerController.instance.SetPowerUpText("Pick-Up Range");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ChangeCoinCollectorSize(1);
        PlayerController.instance.SetPowerUpText("");
    }
}
