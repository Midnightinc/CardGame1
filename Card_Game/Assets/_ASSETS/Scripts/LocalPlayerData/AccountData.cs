using PlayFab.ClientModels;
using UnityEngine;

namespace LocalPlayerData
{
    public class AccountData : MonoBehaviour
    {
        private static AccountData _instance;

        public static AccountData Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance;
                }
                else
                {
                    throw new System.Exception("Account Data object now found");
                }
            }
        }

        public LoginResult data;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(this.gameObject);

#if UNITY_EDITOR
                print($"Account Data Instance duplicate present on {gameObject.name}");
#endif
            }
        }
    }
}
