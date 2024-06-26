using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TwinCAT.Routes
{
    public static class TwinCatRouteHelper
    {
        private static readonly Logger mLog = LogManager.GetCurrentClassLogger();

        public static List<AmsRoute> GetAllExistingRoutes()
        {
            List<AmsRoute> result = new List<AmsRoute>();
            result.AddRange(GetRoutesForKey(FindX86RemoteKey(RegistryKeyPermissionCheck.ReadSubTree)));
            result.AddRange(GetRoutesForKey(FindX64RemoteKey(RegistryKeyPermissionCheck.ReadSubTree)));
            return result;
        }

        private static IEnumerable<AmsRoute> GetRoutesForKey(RegistryKey remoteKey)
        {
            if (remoteKey == null)
                return Enumerable.Empty<AmsRoute>();
            List<AmsRoute> result = new List<AmsRoute>();
            foreach (string subKeyName in remoteKey.GetSubKeyNames())
            {
                try
                {
                    RegistryKey subKey = remoteKey.OpenSubKey(subKeyName);
                    if (subKey == null)
                        continue;
                    string address = subKey.GetValue("Address") as string;
                    byte[] amsNetId = subKey.GetValue("AmsNetId") as byte[];
                    result.Add(new AmsRoute(subKeyName, address, amsNetId));
                }
                catch (Exception exc)
                {
                    mLog.Error(exc);
                }
            }
            return result;
        }

        private static RegistryKey FindX64RemoteKey(RegistryKeyPermissionCheck permission)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (key == null)
                return null;
            key = key.OpenSubKey("Wow6432Node");
            if (key == null)
                return null;
            key = key.OpenSubKey("Beckhoff");
            if (key == null)
                return null;
            key = key.OpenSubKey("TwinCAT");
            if (key == null)
                return null;
            key = key.OpenSubKey("Remote", permission);
            return key;
        }

        private static RegistryKey FindX86RemoteKey(RegistryKeyPermissionCheck permission)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (key == null)
                return null;
            key = key.OpenSubKey("Beckhoff");
            if (key == null)
                return null;
            key = key.OpenSubKey("TwinCAT");
            if (key == null)
                return null;
            key = key.OpenSubKey("Remote", permission);
            return key;
        }
    }
}
