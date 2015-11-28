using UnityEngine;
using System.Collections;

public class SurvivalShooter : GameClass
{
    public PlayerController playercontroller;
    public EnemyController enmctrl;

    new public void MoveXRaw(float axisx)
    {
        playercontroller.MoveXRaw(axisx);
    }
    new public void MoveYRaw(float axisy)
    {
        playercontroller.MoveYRaw(axisy);
    }
    public override void IncreaseDifficulty()
    {
        difficulty++;
        enmctrl.resettime *= 0.9f;
    }
    public override void ReduceDifficulty()
    {
        difficulty--;
        enmctrl.resettime /= 0.9f;
    }
}