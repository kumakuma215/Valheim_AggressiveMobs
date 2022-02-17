using System;
using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggressiveMobs
{
    [BepInPlugin("kumakuma215.AggressiveMobs", "Aggressive mobs", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class AggressiveMobs : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("kumakuma215.AggressiveMobs");

        void Awake()
        {
            harmony.PatchAll();
            
        }

        [HarmonyPatch(typeof(BaseAI), nameof(BaseAI.IsEnemy))]
        class Aggro_Patch
        {
            static bool Prefix(Character a, Character b, ref bool __result)
            {
                if(a != b) {
                    __result = a.m_name != b.m_name;
                    return false;
                }

                return true;
            }
        }
    }
}
