using Data.Configs;
using Data.Loaders;
using Doorstop;
using HarmonyLib;
using HollywoodAnimalQOL2.Objects;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(DataManager), "UpdateData")]
    [HarmonyPatchCategory("beforeGameLoad")]
    internal class DataManagerUpdateDataPatch
    {
        static bool postfixProcess = false;
        static void Prefix(DataManager __instance, Dictionary<string, CharacterConfig> ___characters)
        {

            Entrypoint.harmony.PatchAllUncategorized();
            Logger.Log("Patching completed");

            Entrypoint.AfterPatch();

            //HelperObject.LocalizationManager = ___localizationManager;
            //Loggerns.Logger.Log("UpdateData called");
            //if (___characters == null)
            //{
            //    Loggerns.Logger.Log("UpdateData called and cache is null");
            //    postfixProcess = true;
            //}

        }
        static void Postfix(Dictionary<string, CharacterConfig> ___characters)
        {
            //if (postfixProcess)
            //{
            //    foreach (var item in CustomCharacter.GetCustomCharacters())
            //    {
            //        ___characters.Add(item.Id, item);
            //        postfixProcess = false;
            //    }
            //}
        }
    }
}
