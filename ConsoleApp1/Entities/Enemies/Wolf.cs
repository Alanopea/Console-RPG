using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Entities.Enemies
{
    public class Wolf : Enemy
    {
        public Wolf() : base(
            "Wolf",
            20,
            15,
            5,
            new List<(string, int, int)>
            {
                ("Claw", 6, 18),
                ("Bite", 8, 16)
            })
        { }
    }
}
