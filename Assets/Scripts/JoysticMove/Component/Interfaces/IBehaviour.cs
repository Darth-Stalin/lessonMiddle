using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson2M.Assets.Scripts.JoysticMove.Component.Interfaces
{
    public interface IBehaviour
    {
        float Evaluate();
        void Behave();
    }
}