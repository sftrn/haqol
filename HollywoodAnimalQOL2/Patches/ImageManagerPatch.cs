using Data.Configs;
using Data.GameObject.Character;
using Enums;
using HarmonyLib;
using HollywoodAnimalQOL2.Objects;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Lists.ItemView;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(ImageManager), "GetPortraitId")]
    internal class ImageManagerGetPortraitIdPatch
    {
        static void Postfix(CharacterDataWrapper character, ref string __result)
        {
            Logger.Log("Requesting image id: " + __result);
        }
    }
    [HarmonyPatch(typeof(ImageManager), "GetPortraitIdFromConfigForAgeGroup")]
    internal class ImageManagerGetPortraitIdFromConfigForAgeGroupPatch
    {
        static void Postfix(PortraitConfig config, int ageGroup, ref string __result)
        {
            Logger.Log("GetPortraitIdFromConfigForAgeGroup Requesting image id: " + __result);
        }
    }
    public class InternalImageManager
    {
        static MethodInfo AddToCacheInt;
        static ImageManager Instance { get; set; }
        public static void InitPrivateMethods(ImageManager instance)
        {
            Instance = instance;
            AddToCacheInt =
                typeof(ImageManager).GetMethod("AddToCache", new Type[] {typeof(Texture), typeof(ImageType), typeof(string) }
                );
        }
        public static void AddCharacterPortrait(Texture image, CharacterDataWrapper character)
        {
            var type = ImageType.Portrait;
            var imageId = Instance.GetPortraitId(character);
            Logger.Log("Added new portrait by id: " + imageId);
            AddToCacheInt.Invoke(Instance, new object[] { image, type, imageId });
        }
    }

}
