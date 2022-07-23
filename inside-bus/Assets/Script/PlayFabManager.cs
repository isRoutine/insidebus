using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayFabManager : MonoBehaviour
{

    /* Leadeboard */
    public GameObject rowPrefab;
    public Transform rowsParent;

    /* Profile */
    public TMP_Text usernameText;
    public TMP_Text playeridText;
    public TMP_Text createdOnText;
    public TMP_Text lastLoginText;
    public TMP_Text emailUtenteText;

    /* login and register */
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;

    private string playFabId;
    private bool confirmed = true;

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
            DisplayName = usernameInput.text,
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        messageText.text = "Registration successful!";
        Debug.Log("Registration successful!");
        
        /* invio verifica dell'email */
        AddOrUpdateContactEmail(result.PlayFabId, emailInput.text);

        /* reindirizzo alla schermata di login */
        this.LoginScreen();
    }

    public void LoginButton(){

        /* se tutto va bene faccio la richiesta di login */
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }


    void OnLoginSuccess(LoginResult result){
        messageText.text = "Logged in!";
        Debug.Log("Successful login!");
        playFabId = result.PlayFabId;
        Debug.Log("id: " + playFabId);

        /* posso passare alla schermata di gioco se l'email è verificata */
        ControlContactEmailStatus();

        if(confirmed){
            this.MenuGiocoScreen();
        }
    }

    void AddOrUpdateContactEmail(string pFId, string emailAddress) {
        var request = new AddOrUpdateContactEmailRequest {
            /*PlayFabId = pFId,*/
            EmailAddress = emailAddress
        };

        PlayFabClientAPI.AddOrUpdateContactEmail(request, result => {
            Debug.Log("The player's account has been updated with a contact email");
        }, OnError);
    }

    void ControlContactEmailStatus(){
        var request = new GetPlayerProfileRequest {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints(){
                ShowContactEmailAddresses = true,
                ShowLastLogin = true,
                ShowCreated = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetPlayerProfile(request, OnEmalInfoReceived, OnError);
    }

    void OnEmalInfoReceived(GetPlayerProfileResult result){
        confirmed = false;

        foreach(var item in result.PlayerProfile.ContactEmailAddresses){
            if(item.EmailAddress == emailInput.text){
                if(item.VerificationStatus == PlayFab.ClientModels.EmailVerificationStatus.Confirmed) {
                    confirmed = true;
                }
            }
        }

        if(confirmed){
            Debug.Log("L'Email inserita è stata verificata!");
        }else{
            Debug.Log("L'Email inserita non è stata ancora verificata!");
            messageText.text = "Email non verificata!";
        }
        
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

    public void ProfilePanelInfo(){
        var request = new GetPlayerProfileRequest {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints(){
                ShowContactEmailAddresses = true,
                ShowLastLogin = true,
                ShowCreated = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetPlayerProfile(request, OnProfileInfoReceived, OnError);
    }

    void OnProfileInfoReceived(GetPlayerProfileResult result){
        Debug.Log("DisplayName :" + result.PlayerProfile.DisplayName);
        Debug.Log("last login :" + result.PlayerProfile.LastLogin);
        Debug.Log("PlayerID :" + result.PlayerProfile.PlayerId);
        Debug.Log("Created :" + result.PlayerProfile.Created);

        usernameText.text = result.PlayerProfile.DisplayName;
        playeridText.text = result.PlayerProfile.PlayerId;

        createdOnText.text = result.PlayerProfile.Created.ToString();
        lastLoginText.text = result.PlayerProfile.LastLogin.ToString();
        
        foreach(var item in result.PlayerProfile.ContactEmailAddresses){
            emailUtenteText.text=item.EmailAddress;
        }


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

        foreach(Transform item in rowsParent){
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard){

            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);

        }

    }








}
