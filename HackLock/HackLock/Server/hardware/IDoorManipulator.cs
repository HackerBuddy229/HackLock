using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackLock.Server.hardware
{
    public interface IDoorManipulator
    {
        public DateTime LastAction { get; set; }
        public bool IsLocked { get; set; }

        public void Unlock();
        public void Lock();
        public void Toggle();

        public void Cycle(int delayS = 15);
    }
}
