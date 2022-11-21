using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Static class to store all sprite configurations For easier organization, an to make it easier to change all sprites of a type.
    /// 
    /// </summary>
    internal static class SpriteConfig
    {
        public static Sprite PlayerSprite => new(" ^ \n^^^");
        public static Sprite EnemySprite => new("xxx\n\\v/");
        public static Sprite BulletSprite => new("o");
        public static Sprite EnemyBulletSprite => new("|");
    }
}
