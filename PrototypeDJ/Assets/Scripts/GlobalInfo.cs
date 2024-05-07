public static class GlobalInfo
{
    public enum EI
    {
        E, I
    }
    
    public enum SN
    {
        S, N
    }
    
    public enum TF
    {
        T, F
    }
    
    public enum JP
    {
        J, P
    }

    public static int CurrentCharacterIndex { get; set; } = 999;
    public static int CurrentPetIndex { get; set; } = 999;
    public static EI CurrentEI { get; set; }
    public static SN CurrentSN { get; set; }
    public static TF CurrentTF { get; set; }
    public static JP CurrentJP { get; set; }
}