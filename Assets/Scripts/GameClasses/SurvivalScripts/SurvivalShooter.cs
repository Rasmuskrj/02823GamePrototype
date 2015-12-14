using UnityEngine;
using System.Collections;

public class SurvivalShooter : GameClass
{
    public PlayerController playercontroller;
    public EnemyController enmctrl;
    private int progressOnToken = 0;
    public int requirementForToken = 15;

    void Start()
    {
        enmctrl.isAI = isAI;
        enmctrl.shooter = this;
        enmctrl.playerHealth.main = this;
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
        playercontroller.fireRate *= 0.9f;
    }
    public override void ReduceDifficulty()
    {
        if (difficulty == 0) { Tokens++; return; }
        difficulty--;
        enmctrl.resettime /= 0.9f;
        playercontroller.fireRate /= 0.9f;
    }
    public void DoOnDestroyedBlock()
    {
        progressOnToken++;
        if (progressOnToken >= requirementForToken)
        {
            progressOnToken -= requirementForToken;
            Tokens++;
            if (isAI) { AIUseToken(); }
        }
    }
}