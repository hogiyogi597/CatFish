using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    public static class Utils
    {

        public enum Orientation { X, Y, Z };
        public enum Direction { UP, RIGHT, DOWN, LEFT };


        public static int ToDirectionalInt(Direction d)
        {
            return d == Direction.RIGHT || d == Direction.UP ? 1 : -1;
        }

    }
}
