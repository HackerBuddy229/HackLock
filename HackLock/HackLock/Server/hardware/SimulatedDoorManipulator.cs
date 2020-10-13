using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HackLock.Server.hardware
{
    public class SimulatedDoorManipulator : IDoorManipulator
    {
        private readonly ILogger<SimulatedDoorManipulator> _logger;

        public SimulatedDoorManipulator(ILogger<SimulatedDoorManipulator> logger)
        {
            _logger = logger;
        }

        public DateTime LastAction { get; set; } = DateTime.Now.AddSeconds(-11);
        public bool IsLocked { get; set; }

        private bool ActionAllowed => 
            DateTime.Now - LastAction > TimeSpan.FromSeconds(10);


        public void Unlock()
        {
            if (!ActionAllowed)
                return;

            LastAction = DateTime.Now;
            IsLocked = false;

            
            _logger.LogInformation("door unlocked");
        }

        public void Lock()
        {
            if (!ActionAllowed)
                return;

            LastAction = DateTime.Now;
            IsLocked = true;
            
            _logger.LogInformation("door locked");
        }

        public void Toggle()
        {
            if (IsLocked)
                Unlock();
            else
                Lock();
            
        }

        public void Cycle(int delayS = 15)
        {
            if (delayS < 10 || delayS > 60)
                return;

            Unlock();
            Thread.Sleep(delayS*1000);
            Lock();
        }
    }
}
