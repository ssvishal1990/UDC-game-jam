using System.Collections;
using UnityEngine;

namespace UDC_gameJam_player
{
    public class Abilities : Character
    {

        protected Character character;

        protected override void initialize()
        {
            base.initialize();
            character = GetComponent<Character>();
        }
    }
}