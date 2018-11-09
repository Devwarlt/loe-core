﻿using LoESoft.Server.Core.Networking.Packets.Outgoing;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Register : IncomingPacket
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override PacketID PacketID => PacketID.REGISTER;

        public override void Handle(Client client)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = -1,
                    Content = "Account name is empty."
                });
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = -1,
                    Content = "Account password is empty."
                });
                return;
            }

            if (Name.Length < 6)
            {
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = -1,
                    Content = "Account name minimum length is 6."
                });
                return;
            }

            if (Password.Length < 8)
            {
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = -1,
                    Content = "Account password minimum length is 8."
                });
                return;
            }

            var isAccountNameExist = App.Database.CheckAccountNameIfExists(Name);

            if (isAccountNameExist)
            {
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = -1,
                    Content = "Account name already registered."
                });
                return;
            }

            if (App.Database.CreateNewAccount(Name, Password, out string token))
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = 0,
                    Content = $"You have successfully registered a brand-new account with token '{token}', enjoy the game!"
                });
            else
                client.SendPacket(new Response()
                {
                    From = "Register",
                    Result = -1,
                    Content = "An error occurred while account registration, try again later..."
                });
        }
    }
}