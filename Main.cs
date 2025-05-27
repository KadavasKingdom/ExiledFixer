using HarmonyLib;
using LabApi.Events.CustomHandlers;
using LabApi.Loader.Features.Plugins;
using LabApi.Loader.Features.Plugins.Enums;

namespace ExiledFixer;

internal sealed class Main : Plugin
{
    public static Main Instance { get; private set; }
    #region Plugin Info
    public override string Author => "SlejmUr";
    public override string Name => "ExiledFixer";
    public override Version Version => new(0, 1);
    public override string Description => "Fix Exiled related bugs with BaseGame.";
    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;
    public override LoadPriority Priority => LoadPriority.Highest;
    #endregion
    private Harmony Harmony;
    public List<CustomEventsHandler> CustomEvents = [];
    public override void Enable()
    {
        Instance = this;
        CustomEvents.AddRange([
            new Fixes.EscapingAndEscaped()
        ]);
        AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        Harmony = new(typeof(Main).Namespace);
        foreach (var item in CustomEvents)
        {
            CustomHandlersManager.RegisterEventsHandler(item);
        }
    }

    private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
        if (!args.LoadedAssembly.FullName.Contains("Exiled.Events"))
            return;
        Harmony.PatchAll();
        CL.Info("Exiled events patched!");
    }

    public override void Disable()
    {
        Instance = null;
        AppDomain.CurrentDomain.AssemblyLoad -= CurrentDomain_AssemblyLoad;
        Harmony.UnpatchAll(typeof(Main).Namespace);
        foreach (var item in CustomEvents)
        {
            CustomHandlersManager.UnregisterEventsHandler(item);
        }
        CustomEvents.Clear();
    }
}
