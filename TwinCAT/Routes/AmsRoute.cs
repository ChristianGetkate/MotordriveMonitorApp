using System;

namespace TwinCAT.Routes
{
    public class AmsRoute
    {
        public AmsRoute(string name, string address, byte[] amsNetId)
            : this(name, address, amsNetId, 0, 0, 1)
        {
        }

        public AmsRoute(string name, string address, byte[] amsNetId, uint flags, uint timeout, uint transporttype)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentOutOfRangeException("name");
            if (string.IsNullOrEmpty(address))
                throw new ArgumentOutOfRangeException("address");
            if (amsNetId == null || amsNetId.Length != 6)
                throw new ArgumentOutOfRangeException("amsNetId");

            Name = name;
            Address = address;
            AmsNetId = amsNetId;
            Flags = flags;
            Timeout = timeout;
            Transporttype = transporttype;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public byte[] AmsNetId { get; private set; }

        public uint Flags { get; private set; }

        public uint Timeout { get; private set; }
        
        public uint Transporttype { get; private set; }

        public string GetAmsNetIdString()
        {
            return string.Format("{0:0}.{1:0}.{2:0}.{3:0}.{4:0}.{5:0}",
                                 AmsNetId.Length > 0 ? AmsNetId[0] : 0,
                                 AmsNetId.Length > 1 ? AmsNetId[1] : 0,
                                 AmsNetId.Length > 2 ? AmsNetId[2] : 0,
                                 AmsNetId.Length > 3 ? AmsNetId[3] : 0,
                                 AmsNetId.Length > 4 ? AmsNetId[4] : 0,
                                 AmsNetId.Length > 5 ? AmsNetId[5] : 0);
        }
    }
}
