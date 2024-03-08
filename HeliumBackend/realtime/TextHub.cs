using HeliumBackend.interfaces;
using Microsoft.AspNetCore.SignalR;

namespace HeliumBackend.realtime;

public class TextHub (ICueService cueService) : Hub
{
    private static Dictionary<string, string> _connectionsNgroup = new Dictionary<string, string>();
    //private static Dictionary<string, string> _LastTextForGroup = new Dictionary<string, string>();

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        if (_connectionsNgroup.ContainsKey(Context.ConnectionId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, _connectionsNgroup[Context.ConnectionId]);
            _connectionsNgroup.Remove(Context.ConnectionId);
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task BroadcastText(string text)
    {
        if (_connectionsNgroup.ContainsKey(Context.ConnectionId))
        {
            //_LastTextForGroup[Context.ConnectionId] = text;
            await Clients.OthersInGroup(_connectionsNgroup[Context.ConnectionId]).SendAsync("ReceiveText", text);
        }
    }

    public async Task JoinGroup(string group)
    {
        if (_connectionsNgroup.ContainsKey(Context.ConnectionId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, _connectionsNgroup[Context.ConnectionId]);
            _connectionsNgroup.Remove(Context.ConnectionId);
        }
        _connectionsNgroup.Add(Context.ConnectionId, group);
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
    }
    
}