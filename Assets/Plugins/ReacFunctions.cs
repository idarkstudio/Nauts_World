using System.Runtime.InteropServices;

public static class ReacFunctionsInternal
{
    [DllImport("__Internal")]
    public static extern void GetNFT();
    [DllImport("__Internal")]
    public static extern void Login();
    [DllImport("__Internal")]
    public static extern void SetUserName(string json);
}

public static class ReacFunctions
{
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
}
