using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LocalPlayerData
{
    public static class PlayerDataHandler
    {
        private const string UserKey = "P_USR_";
        private const string PassKey = "P_PSD";

        public static bool DataExists()
        {
            return PlayerPrefs.HasKey(UserKey) && PlayerPrefs.HasKey(PassKey);
        }

        public static PlayerData Get()
        {
            return new PlayerData { email = PlayerPrefs.GetString(UserKey), pass = PlayerPrefs.GetString(PassKey) };
        }

        public static void Set(string usr, string pass)
        {
            PlayerPrefs.SetString(UserKey, usr);
            PlayerPrefs.SetString(PassKey, pass);
        }


        public struct PlayerData
        {
            public string email;
            public string pass;
        }
    }
}
