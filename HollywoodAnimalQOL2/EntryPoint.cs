using Data.Configs;
using HarmonyLib;
using HollywoodAnimalQOL2;
using HollywoodAnimalQOL2.Objects;
using HollywoodAnimalQOL2.Patches;
using Loggerns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace Doorstop
{
    class Entrypoint
    {
        //Event offset: 6702
        public static Harmony harmony;
        public static bool IsVerbose = true;
        public static void Start()
        {
            Logger.Init("haqol", false);
            try
            {
                PreproductionEditorViewPatch.InitPrivateMethods();
                GUISystemHideViewPatch.InitPrivateMethods();
                harmony = new Harmony("com.qwerty.qol.hollywoodanimal");
                Harmony.DEBUG = true;
                harmony.PatchCategory("beforeGameLoad");
                Logger.Log("Harmony init complete");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }
        
        public static void AfterPatch()
        {
            List<CustomCharacter> characters = new List<CustomCharacter>()
            {
                new CustomCharacter()
                {
                    FirstName = "Leonid",
                    LastName = "Konevsky",
                    Profession = Enums.Professions.Actor,
                    IconPath = "CharacterIcons/LeonidKonevsky.png",
                }
            };
            var json = JsonUtility.ToJson(characters);

            File.WriteAllText("characters.json", json);
        }
    }

}

