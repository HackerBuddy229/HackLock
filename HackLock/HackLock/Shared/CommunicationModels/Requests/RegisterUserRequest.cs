﻿using System.Reflection.Emit;

namespace HackLock.Shared.CommunicationModels.Requests
{
    public class RegisterUserRequest
    {

        public string Name { get; set; }
        public string Class { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
