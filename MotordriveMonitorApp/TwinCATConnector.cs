using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace MotordriveMonitorApp
{
    public class TwinCATConnector
    {
        private AdsClient adsClient = new AdsClient();
        private Dictionary<string, uint> readvalues = new Dictionary<string, uint>();

        uint valueToRead = 0;

        public void Connect(string amsNetId, int port)
        {
            adsClient.Connect(amsNetId, port); // AmsNetId.LocalHost
        }

        //===================================================================================
        // This function adds a value to the readvalues dictionary.
        // Parameters: location (location of variable in PLC program), type (which datatype)
        //===================================================================================
        public void AddReadValue(string location, Type type)
        {
            valueToRead = (uint)adsClient.CreateVariableHandle(location);
            readvalues.Add(location, valueToRead);
        }

        public Dictionary<string, uint> ReadValues()
        {
            Dictionary<string, uint> result = new Dictionary<string, uint>();

            foreach (string key in readvalues.Keys)
            {
                result.Add(key, adsClient.ReadAny<uint>(readvalues[key]));
            }

            return result;
        }
    }
}

