﻿using EnvDTE;
using SpearSoft.Games.Dicey.GameEngine;

namespace SpearSoft.Games.Dicey.UI.Winforms
{
    public static class Globals
    {
        public static IDiceSet Dice { get; set; }
        public static Game Game { get; set; }
    }
}