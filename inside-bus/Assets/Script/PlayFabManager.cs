using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private GameObject resetPassUI;
    [SerializeField]
    private GameObject passwordInputUI;

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
        /*string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
            name=result.InfoResultPayload.PlayerProfile.DisplayName;*/
    }

    public void ResetPasswordButton(){
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "BBB84"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset (SendAccountRecoveryEmailResult result){
        messageText.text = "Richiesta per reset password inviata correttamente! Controlla la tua email";
    } 

    /* UI */
    public void ClearUI()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        resetPassUI.SetActive(false);
        messageText.text = "";
        emailInput.text = "";
        passwordInput.text = "";
    }

    public void LoginScreen()
    {
        ClearUI();
        passwordInputUI.SetActive(true);
        loginUI.SetActive(true);
    }

    public void RegisterScreen()
    {
        ClearUI();
        passwordInputUI.SetActive(true);
        registerUI.SetActive(true);
    }

    public void ResetPassScreen()
    {
        ClearUI();
        resetPassUI.SetActive(true);
        passwordInputUI.SetActive(false);
    }

    public void MenuGiocoScreen()
    {
        SceneManager.LoadScene("MainMenu Scene");
        Time.timeScale = 1f;
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
            Debug.Log(item.Position + " " + item.Profile.DisplayName + " " + item.StatValue);
        }
    }








}
