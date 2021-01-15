using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class JsonPlayerReposotory : IPlayerRepository
{
    private readonly string _path;
    public Player Player = new Player()
    { Username = "Unnamed" };
    public Player CurrentPlayer => new Player
    {
        Username = File.ReadAllText(_path)
    };

    public JsonPlayerReposotory(string path)
    {
        _path = path;
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, Player.Username);
        }
    }
    public void UpdateUsername(string newUsername)
    {
        Player.Username = newUsername;
        File.WriteAllText(_path, Player.Username);
    }
}
