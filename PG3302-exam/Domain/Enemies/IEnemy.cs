﻿using System;

namespace Domain.Enemies
{
    public interface IEnemy
    {
        Point Pos { get; set; }
        Sprite ActiveSprite { get; set; }

        int Speed();

        void Move();

        void Update();
    }
}

