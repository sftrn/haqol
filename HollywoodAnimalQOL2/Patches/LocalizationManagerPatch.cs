using HarmonyLib;
using HollywoodAnimalQOL2.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Animations;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(LocalizationManager), "Initialize")]
    internal class LocalizationManagerInitializePatch
    {
        public static bool Inited = false;
        static void Prefix(LocalizationManager __instance)
        {
        }
        static void Postfix(LocalizationManager __instance)
        {
            if (Inited)
                return;
            Inited = true;
            HelperObject.LocalizationManager = __instance;

            //Loggerns.Logger.Log("LocalizationManager Initialize called");
            //foreach (var item in CustomCharacter.GetCustomCharacters())
            //{
            //    HelperObject.Characters.Add(item.Id, item);
            //}
        }
    }
}
