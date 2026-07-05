using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "Spell", menuName = "Spell")]
public class SO_Spell : ScriptableObject {
    public int id;
    public int level;
    public SpellSchool spellSchool;
    public TargetRule targetShape;
    public int range;
    public float size;
    public BaseStat saveType;
    public DamageFormula damageFormula;
    public ConditionType conditionType;
    public bool concentration;
    public VisualEffectAsset effect;
}
[Serializable]
public class DamageFormula {
    public List<DamageStat> damageStats;
}
[Serializable]
public class DamageStat {
    public int number;
    public DamageType damageType;
    public List<DiceType> damage;
}