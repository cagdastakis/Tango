﻿using System.IO;
using ProtoBuf;

namespace CSM.Commands
{
    /// <summary>
    ///     Returned from the server after the server recieves
    ///     as connection request command. Contains if the server
    ///     accepts the connection or not (wrong password, incorrect mods,
    ///     different game version etc.)
    /// </summary>
    [ProtoContract]
    public class ConnectionResultCommand : CommandBase
    {
        /// <summary>
        ///     If the server accepts the connection
        /// </summary>
        [ProtoMember(1)]
        public bool Success { get; set; }

        /// <summary>
        ///     If success is false, this will contain a reason why
        ///     the serve rejected the request.
        /// </summary>
        [ProtoMember(2)]
        public string Reason { get; set; }

        /// <summary>
        ///     Deserialize a message into this type.
        /// </summary>
        public static ConnectionResultCommand Deserialize(byte[] message)
        {
            ConnectionResultCommand result;

            using (var stream = new MemoryStream(message))
            {
                result = Serializer.Deserialize<ConnectionResultCommand> (stream);
            }

            return result;
        }
    }
}