﻿using Domain;
using Domain.Data;
using Domain.Core;
using System.Diagnostics;

namespace View
{
    public class Player : IMovable, IHittable
    {
        private Sprite _activeSprite = new ();
        private Point _pos;
        private Stopwatch _attackTimer = new ();
        private readonly int _attackDelayMs = 100;

        public Player() {
            _attackTimer.Start();

            Speed = 1;
            MoveDir = new Point(0, 0);
            Mask = IHittable.HitMask.Player;
        }
        public Point Pos {
            get => _pos;
            set {
                if (value.Y < 0)
                    value.Y = 0;
                _pos = value;
                _activeSprite.Pos = _pos;
            }
        }
        public Sprite ActiveSprite {
            get {
                return _activeSprite;
            }
            set {
                if (value != null)
                    _activeSprite = value;
            }
        }
        public bool CanAttack { get => _attackTimer.ElapsedMilliseconds > _attackDelayMs; }
        public int Speed { get; set; }
        public Point MoveDir { get; set; }
        public Dimension Size => ActiveSprite.Size;

        public IHittable.HitMask Mask { get; set; }

        public Bullet Attack() {
            Point startPos = new Point(Pos.X + (ActiveSprite.Size.Width / 2), Pos.Y - 1);
            Bullet b = new Bullet(startPos, 1);

            // The players bullets need to hit enemies
            b.Mask = IHittable.HitMask.Enemy;

            _attackTimer.Restart();
            return b;
        }

        public bool Hit(IHittable other) {
            return CollisionHelpers.AABBHit(this, other);
        }
    }
}
