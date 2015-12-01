using UnityEngine;
using System.Collections;

public class SurvivalShooter : GameClass
{
    public PlayerController playercontroller;
    public EnemyController enmctrl;

    void Update()
    {
        base.Update();
    }

    public override void MoveXRaw(float axisx)
    {
        playercontroller.MoveXRaw(axisx);
    }
    public override void MoveYRaw(float axisy)
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