using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace ExiledFixer.Fixes;

internal class EscapingAndEscaped : CustomEventsHandler
{
    public override void OnPlayerEscaping(PlayerEscapingEventArgs ev)
    {
        Exiled.Events.EventArgs.Player.EscapingEventArgs escapingEventArgs = new(ev.Player.ReferenceHub, ev.NewRole, (Exiled.API.Enums.EscapeScenario)ev.EscapeScenario)
        {
            IsAllowed = ev.IsAllowed
        };
        if (escapingEventArgs.IsAllowed)
            escapingEventArgs.IsAllowed = ev.EscapeScenario != Escape.EscapeScenarioType.None;
        Exiled.Events.Handlers.Player.OnEscaping(escapingEventArgs);
        ev.EscapeScenario = (Escape.EscapeScenarioType)escapingEventArgs.EscapeScenario;
        ev.NewRole = escapingEventArgs.NewRole;
        ev.IsAllowed = escapingEventArgs.IsAllowed;
    }

    public override void OnPlayerEscaped(PlayerEscapedEventArgs ev)
    {
        var player = Exiled.API.Features.Player.Get(ev.Player.ReferenceHub);
        Exiled.Events.EventArgs.Player.EscapedEventArgs escapedEvent = new(player, (Exiled.API.Enums.EscapeScenario)ev.EscapeScenarioType, player.Role);
        Exiled.Events.Handlers.Player.OnEscaped(escapedEvent);
    }
}
