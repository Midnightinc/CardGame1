using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LocalPlayerData;
using UnityEngine.UI;

public class PlayFabLoginFlowHandler : MonoBehaviour
{

    private const string TITLE_ID = "2C3FA";



    enum FlowMainState { Login, Create }

    private FlowMainState _mainState;

    private void SetMainState(FlowMainState state)
    {
        switch (state)
        {
            case FlowMainState.Login:

                break;
            case FlowMainState.Create:
                inputFieldParent.SetActive(true);
                loginButton.gameObject.SetActive(false);
                createButton.gameObject.SetActive(true);

                break;
            default:
                break;
        }
    }


    [SerializeField] private GameObject inputFieldParent;

    [SerializeField] private TMP_Text statusText;

    [SerializeField] private TMP_InputField input_emailAddress;
    [SerializeField] private TMP_InputField input_username;
    [SerializeField] private TMP_InputField input_password;

    [SerializeField] private Button loginButton;
    [SerializeField] private Button createButton;

    private void Awake()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = TITLE_ID;
        }


        inputFieldParent.SetActive(false);
        _mainState = FlowMainState.Login;

        (PlayerDataHandler.DataExists() ? (Action)StartAutoLogin : BeginAccountCreate)();
    }


    private void Start()
    {
        //var request = new LoginWithCustomIDRequest { CustomId = "CardGame", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }


    private void OnLoginSuccess(LoginResult obj)
    {
        Destroy(this.gameObject);
        AccountData.Instance.data = obj;
    }

    #region Auto Login

    private void StartAutoLogin()
    {
        var data = PlayerDataHandler.Get();
        var request = new LoginWithEmailAddressRequest { Email = data.email, Password = data.pass };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnFailedAutoLogin);
    }

    private void OnFailedAutoLogin(PlayFabError obj)
    {
        statusText.text = $"Auto Login Failed, Please create an Account";
        SetMainState(FlowMainState.Create);
    }
    #endregion

    #region Manual Login

    private void OnLoginFailure(PlayFabError obj)
    {
        inputFieldParent.SetActive(true);
    }


    #endregion

    #region Account Creation

    private void BeginAccountCreate()
    {
        if (_mainState != FlowMainState.Create)
        {
            SetMainState(FlowMainState.Create);
        }

        createButton.onClick.AddListener(() =>
        {
            var registerRequest = new RegisterPlayFabUserRequest { Username = input_username.text, Email = input_emailAddress.text, Password = input_password.text };
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnNewAccountSuccess, OnNewAccountFailed);
        });
    }

    private void OnNewAccountSuccess(RegisterPlayFabUserResult obj)
    {
        PlayerDataHandler.Set(input_emailAddress.text, input_password.text);
        StartAutoLogin();
    }

    private void OnNewAccountFailed(PlayFabError obj)
    {
        statusText.text = $"Something went wrong, please try again.";
        print($"{obj.ErrorMessage}");
    }
    #endregion

}
