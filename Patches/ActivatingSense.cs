using HarmonyLib;

namespace ExiledFixer.Patches;

[HarmonyPatch(typeof(Exiled.Events.Patches.Events.Scp049.ActivatingSense), nameof(Exiled.Events.Patches.Events.Scp049.ActivatingSense.Transpiler))]
internal static class ActivatingSense
{
    [HarmonyPrefix]
    public static bool Prefix(IEnumerable<CodeInstruction> instructions, ref IEnumerable<CodeInstruction> __result)
    {
        __result = instructions;
        return false;
    }
}
