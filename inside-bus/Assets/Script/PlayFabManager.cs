using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayFabManager : MonoBehaviour
{

    /* login and register */
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;

    [Header("SCREEN")]
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject registerUI;

    public void RegisterButton(){

        if(passwordInput.text.Length < 6) {
            messageText.text = "Password troppo corta!";
            return;
        }

        if(!(passwordInput.text).Equals(confirmPasswordInput.text)){
            messageText.text = "Le Password inserite non coincidono!";
            return;
        }

        var request = new RegisterPlayFabUserRequest(){
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        messageText.text = "Registered and logged in!";
        Debug.Log("Registered and logged in!");
        /* posso passare alla schermata di gioco o profilo */
    }

    public void LoginButton(){
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }


    void OnLoginSuccess(LoginResult result){
        messageText.text = "Logged in!";
        Debug.Log("Successfull login/account create!");
        /* posso passare alla schermata di gioco */
    }

    public void ResetPasswordButton(){

    }

    void OnPasswordReset (SendAccountRecoveryEmailResult result){

    } 

    /* UI */
    public void ClearUI()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        messageText.text = "";
    }

    public void LoginScreen()
    {
        ClearUI();
        loginUI.SetActive(true);
    }

    public void RegisterScreen()
    {
        ClearUI();
        registerUI.SetActive(true);
    }




    // Start is called before the first frame update
    void Start()
    {
        //Login();
    }

    /* LOGIN ANONIMO - guest

    void Login(){
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }*/

    void OnError(PlayFabError error){
        Debug.Log("Error while login/creating account!");
        Debug.Log(error.GenerateErrorReport());
        messageText.text = error.ErrorMessage;
    }

    /* funzioni per la classifica */
    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "InsideBusScore",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successfull leaderboard sent");
    }

    public void GetLeaderboard(){
        var request = new GetLeaderboardRequest {
            StatisticName = "InsideBusScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result){
        foreach(var item in result.Leaderboard){
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }








}
