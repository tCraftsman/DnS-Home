using System.IO;
using UnityEngine;

public static class SaveManager {
    static string currentCharacter;
    static string path;

    public static void ChangeCharacter(string newCharacter) {
        currentCharacter = newCharacter;
        path = Path.Combine(Application.persistentDataPath, $"{currentCharacter}.json");
    }

    public static void SaveCharacter(StatSheetData sheet) {
        currentCharacter = sheet.charName;

        string json = JsonUtility.ToJson(sheet, true);
        File.WriteAllText(path, json);
        Debug.Log(path);
    }

    public static StatSheetData LoadCharacter() {
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<StatSheetData>(json);
    }
}
