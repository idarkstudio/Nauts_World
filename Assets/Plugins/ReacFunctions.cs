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
}
