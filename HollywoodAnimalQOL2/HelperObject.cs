using Managers;
using System;

using System.Collections;
using System.Reflection;
using UI.Common.Lists.ItemView;
using UI.Views.MovieEditor;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2
{
    internal class HelperObject : UnityEngine.MonoBehaviour
    {
        public static HelperObject Instance;
        public static bool GameLoaded {  get; set; }
        private void Start()
        {
            Logger.Log("Helper object started");
            Instance = this;
            InitPrivateMethods();
        }
        static MethodInfo SaveGameMethod;

        public static void InitPrivateMethods()
        {
            SaveGameMethod =
                typeof(SaveManager).GetMethod("TryAutoSave",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }
        private void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5) && GameLoaded)
            {
                //SaveGameMethod.Invoke(new object[]);
            }

        }
        public void CallNextFrame(Action action)
        {
            StartCoroutine(CoroutineCallNextFrame(action));
        }
        private IEnumerator CoroutineCallNextFrame(Action action)
        {
            yield return null;
            action();
        }
    }
}
