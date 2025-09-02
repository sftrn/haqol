using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Loggerns;
using Managers;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(CharactersManager), "OnProfileLoaded")]
    static class CharacterManagerPatch
    { 
        static void Postfix()
        {
            Logger.Log("Game loaded patch");
            HelperObject.GameLoaded = true;
        }
    }
}
