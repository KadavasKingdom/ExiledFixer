﻿using HarmonyLib;

namespace ExiledFixer.Patches;

[HarmonyPatch(typeof(Exiled.Events.Patches.Events.Player.EscapingAndEscaped), nameof(Exiled.Events.Patches.Events.Player.EscapingAndEscaped.Transpiler))]
internal static class EscapingAndEscaped
{
    [HarmonyPrefix]
    public static bool Prefix(IEnumerable<CodeInstruction> instructions, ref IEnumerable<CodeInstruction> __result)
    {
        __result = instructions;
        return false;
    }
}
