using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Loggerns;
using Managers;
using Modes;
using System.Reflection;
using System.Linq;
using GUISystemModule;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(CharactersManager), "OnProfileLoaded")]
    static class CharacterManagerPatch
    { 
        static void Postfix(CharactersManager __instance,
            ModeManager ___modeManager,
            TimeManager ___timeManager, GUIHelper ___guiHelper)
        {
            Logger.Log("Profile loaded");
            HelperObject.CharactersManager = __instance;
            HelperObject.ModeManager = ___modeManager;
        }
    }
}
