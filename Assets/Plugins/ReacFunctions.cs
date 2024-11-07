using System.Runtime.InteropServices;

public static class ReacFunctionsInternal
{
    [DllImport("__Internal")]
    public static extern void GetNFT();
    
    
    [DllImport("__Internal")]
    public static extern void Login();
    
    [DllImport("__Internal")]
    public static extern void SetUserName(string json);

    [DllImport("__Internal")]
    public static extern void CreateAcount();


    [DllImport("__Internal")]
    public static extern void SetRaceTime(float time);
    [DllImport("__Internal")]
    public static extern void SetLapTime(float time);
    [DllImport("__Internal")]
    public static extern void GetScore();
    [DllImport("__Internal")]
    public static extern void GetTotalScore();
    [DllImport("__Internal")]
    public static extern void GetTenRace();
    [DllImport("__Internal")]
    public static extern void GetTenLap(); 
    [DllImport("__Internal")]
    public static extern void GetUserNfts();    
    [DllImport("__Internal")]
    public static extern void GetUserStakes();
    [DllImport("__Internal")]
    public static extern void ReturnToMainMenu(string mainmenu );



}

public static class ReacFunctions
{
    public static void CreateAcount()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.CreateAcount();
#endif
    }

    public static void GetNFT()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetNFT();
#endif
    }
    public static void Login()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.Login();
#endif
    }
    public static void SetUserName(string json)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.SetUserName(json);
#endif
    }

    public static void GetUserNfts()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetUserNfts();
#endif
    }    
    
    public static void GetUserStakes()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetUserStakes();
#endif
    }
    
    //leaderboard
    public static void SetRaceTime(float time)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.SetRaceTime(time);
#endif
    }
    public static void SetLapTime(float time)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.SetLapTime( time);
#endif
    }  
    public static void GetScore()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetScore();
#endif
    }
    public static void GetTotalScore()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetTotalScore();
#endif
    }
    public static void GetTenRace()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetTenRace();
#endif
    }
    public static void GetTenLap()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.GetTenLap();
#endif
    }


    public static void ReturnToMainMenu(string mainmenu)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReacFunctionsInternal.ReturnToMainMenu(mainmenu);
#endif
    }

}
