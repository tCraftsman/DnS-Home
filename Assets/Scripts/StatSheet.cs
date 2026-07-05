using AYellowpaper.SerializedCollections;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatSheet : MonoBehaviour {
    public StatSheetData sheet;

    void Start() {
        SaveManager.ChangeCharacter(sheet.charName);
        sheet = SaveManager.LoadCharacter();
    }

    public void SaveStats() {
        SaveManager.ChangeCharacter(sheet.charName);
        SaveManager.SaveCharacter(sheet);
    }

    public void LoadStats(string charName) {
        SaveManager.ChangeCharacter(charName);
        sheet = SaveManager.LoadCharacter();
    }

    public int RollDie(int faces) {
        int temp = Random.Range(1, faces+1);
        if(temp==faces)Debug.Log("Critical Success!");
        else if(temp==1)Debug.Log("Critical Failure!");
        else Debug.Log(temp);
        return temp;
    }

    public int SkillCheck(Proficency skill) {
        return RollDie(20)+sheet.GetBaseCheck(skill);
    }
}

[Serializable]
public class StatSheetData {
    public string charName;
    public int proficency;
    [SerializedDictionary("Stats", "Score")]
    public SerializedDictionary<BaseStat, int> stats = new SerializedDictionary<BaseStat, int>();
    [SerializedDictionary("Proficencies", "Has")]
    public SerializedDictionary<Proficency, Expertise> proficencies = new SerializedDictionary<Proficency, Expertise>();
    [SerializedDictionary("Resistances", "Type")]
    public SerializedDictionary<DamageType, int> resistances = new SerializedDictionary<DamageType, int>();

    public int GetModifier(BaseStat stat) {
        return (stats[stat]-10)/2;
    }
    
    public int GetBaseCheck(Proficency skillCheck) {
        return proficency * proficencies[skillCheck].GetSkill() + GetModifier(proficencies[skillCheck].baseSkill) + proficencies[skillCheck].customBonuses;
    }
}

[Serializable]
public class Expertise {
    public BaseStat baseSkill;
    public bool prof;
    public bool expertise;
    public int customBonuses;
    
    public int GetSkill() {
        int temp = 0;
        if (prof) temp += 1;
        if (expertise) temp += 1;
        return temp;
    }
}
