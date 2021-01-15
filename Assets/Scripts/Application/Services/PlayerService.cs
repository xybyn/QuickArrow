using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerService
{
    private readonly IPlayerRepository _repos;
    public Player Player => _repos.CurrentPlayer;
    public PlayerService(IPlayerRepository repos)
    {
        _repos = repos;
    }

    public void UpdateUsername(string newUsername)
    {
        _repos.UpdateUsername(newUsername);
    }
}
