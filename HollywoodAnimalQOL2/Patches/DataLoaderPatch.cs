using Data.Configs;
using Data.Loaders;
using HarmonyLib;
using HollywoodAnimalQOL2.Objects;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(DataLoader), "TryGetCharactersData")]
    //[HarmonyPatchCategory("beforeGameLoad")]
    internal class DataLoaderTryGetCharactersDataPatch
    {
        static bool postfixProcess = false;
        static void Prefix(Dictionary<string, CharacterConfig> ___charactersDataCache)
        {
            //Loggerns.Logger.Log("TryGetCharactersData called");
            if (___charactersDataCache == null)
            {
                Loggerns.Logger.Log("TryGetCharactersData called and cache is null");
                postfixProcess = true;
            }

        }
        static void Postfix(Dictionary<string, CharacterConfig> ___charactersDataCache)
        {
            if (postfixProcess)
            {
                HelperObject.Characters = ___charactersDataCache;
                
            }
        }
    }
}
