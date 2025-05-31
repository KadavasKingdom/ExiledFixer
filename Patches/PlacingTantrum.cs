using HarmonyLib;

namespace ExiledFixer.Patches;

[HarmonyPatch(typeof(Exiled.Events.Patches.Events.Scp173.PlacingTantrum), nameof(Exiled.Events.Patches.Events.Scp173.PlacingTantrum.Transpiler))]
internal static class PlacingTantrum
{
    [HarmonyPrefix]
    public static bool Prefix(IEnumerable<CodeInstruction> instructions, ref IEnumerable<CodeInstruction> __result)
    {
        __result = instructions;
        return false;
    }
}
