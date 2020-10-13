using System;
using System.Collections.Generic;
using System.Text;

namespace HackLock.Shared.CommunicationModels.Requests
{
    public class AuthenticationRequest
    {

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
