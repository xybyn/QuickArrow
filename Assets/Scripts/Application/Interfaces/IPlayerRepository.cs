using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPlayerRepository
{
    void UpdateUsername(string newUsername);
    Player CurrentPlayer { get; }
}
