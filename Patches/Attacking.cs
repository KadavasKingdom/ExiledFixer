using HarmonyLib;

namespace ExiledFixer.Patches;

[HarmonyPatch(typeof(Exiled.Events.Patches.Events.Scp049.Attacking), nameof(Exiled.Events.Patches.Events.Scp049.Attacking.Transpiler))]
internal static class Attacking
{
    [HarmonyPrefix]
    public static bool Prefix(IEnumerable<CodeInstruction> instructions, ref IEnumerable<CodeInstruction> __result)
    {
        __result = instructions;
        return false;
    }
}
