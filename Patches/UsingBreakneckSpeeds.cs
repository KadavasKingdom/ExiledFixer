using HarmonyLib;

namespace ExiledFixer.Patches;

[HarmonyPatch(typeof(Exiled.Events.Patches.Events.Scp173.UsingBreakneckSpeeds), nameof(Exiled.Events.Patches.Events.Scp173.UsingBreakneckSpeeds.Transpiler))]
internal static class UsingBreakneckSpeeds
{
    [HarmonyPrefix]
    public static bool Prefix(IEnumerable<CodeInstruction> instructions, ref IEnumerable<CodeInstruction> __result)
    {
        __result = instructions;
        return false;
    }
}
