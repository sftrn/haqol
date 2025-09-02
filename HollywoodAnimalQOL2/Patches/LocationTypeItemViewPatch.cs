using Data.GameObject.Movie;
using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Lists.ItemData;
using UI.Common.Lists.ItemView;
using UI.Common.Toggles;
using UI.Views.MovieEditor;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(LocationTypeItemView), "OnUpdate")]
    internal class LocationTypeItemViewPatch
    {
        //static List<LocationTypeItemView> allLocations = new List<LocationTypeItemView>();
        public static void InitPrivateMethods()
        {

        }
        //public static void UodateLocation()
        //{

        //}
        static void Postfix(LocationTypeItemView __instance, bool fromInit, 
            //bool fromInit, 
            SimpleToggle ___indoorToggle)
        {
            //Logger.Log($"OnUpdate with value: {fromInit}");
            //if (fromInit)
            //{
                //Logger.Log("Got location tiv");
            //allLocations.Add(__instance);
        }
            //___indoorToggle.IsOn = true;
            //___indoorToggle.EvToggleValueChanged.Fire(true);
            //Logger.Log($"Choosing locations");
            ////foreach (var item in ___locationsListView.ItemsContainerData)
            ////{
            ////    DebugItemContainerData debugItem = item as DebugItemContainerData;
            ////    LocationTypeItemView.ItemData itemData = debugItem.RawData as LocationTypeItemView.ItemData;
            ////    LocationSlotWrapper slot = itemData.slot;

            //var slot = __instance.Data?.GetData<LocationTypeItemView.ItemData>()?.slot;
            //Logger.Log("Got slot");

            ////LocationTypeOnValueChanged.Invoke(__instance, new object[] { true, true });
            //Logger.Log("Choosen indoor");
            ////LocationTypeOnQualityChanged.Invoke(__instance, new object[] { slot.Config.globalQualityLimit });
            ////}
            //Logger.Log($"Maxing stars on locations");

    }
}
