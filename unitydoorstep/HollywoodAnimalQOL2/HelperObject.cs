using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Logger = Loggerns.Logger;
namespace HollywoodAnimalQOL2
{
    internal class HelperObject : UnityEngine.MonoBehaviour
    {
        public static HelperObject Instance;
        private void Start()
        {
            Logger.Log("Helper object started");
            Instance = this;
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
