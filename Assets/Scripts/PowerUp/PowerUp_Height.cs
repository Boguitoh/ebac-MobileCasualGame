using DG.Tweening;
using UnityEngine;

public class PowerUp_Height : PowerUpBase
{
    [Header("Power Up Height")]
    public float heightAmount = 2;
    public float animationDuration = .6f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.ChangeHeight(heightAmount, powerDuration, animationDuration, ease);
        PlayerController.instance.SetFlyingText("Flying");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetHeight(animationDuration);
        PlayerController.instance.SetFlyingText("");
    }
}
