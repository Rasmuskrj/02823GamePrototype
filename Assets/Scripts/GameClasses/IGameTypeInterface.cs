﻿using UnityEngine;
using System.Collections;

public interface IGameTypeInterface
{
    void SetCamera (Rect rect);
    void MoveX(float axisx);
    void MoveY(float axisy);
    void InceaseDifficulty();
}
