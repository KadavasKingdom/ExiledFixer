using HarmonyLib;

namespace ExiledFixer.Patches;

[HarmonyPatch(typeof(Exiled.Events.Patches.Events.Scp106.Stalking), nameof(Exiled.Events.Patches.Events.Scp106.Stalking.Transpiler))]
internal static class Stalking
{
    [HarmonyPrefix]
    public static bool Prefix(IEnumerable<CodeInstruction> instructions, ref IEnumerable<CodeInstruction> __result)
    {
        __result = instructions;
        return false;
    }
}
