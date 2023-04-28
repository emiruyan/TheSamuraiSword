using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public static string LevelKey = "level";
    public static string CurrencyKey = "currency";
    public static string SoundKey = "sound";
    public static string VibrationKey = "vibration";

    public static int GetCurrency()
    {
        return PlayerPrefs.GetInt(CurrencyKey, 0);
    }

    public static int GetSound()
    {
        return PlayerPrefs.GetInt(Constants.SoundKey, 0);
    }
    
    public static int GetVibration()
    {
        return PlayerPrefs.GetInt(Constants.VibrationKey, 0);
    }
}
