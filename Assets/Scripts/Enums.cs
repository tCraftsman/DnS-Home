public enum DamageType {
    Slashing, Piercing, Bludgeoning,
    Acid, Fire, Cold,
    Poison, Lightning, Thunder,
    Force, Necrotic, Radiant,
    Psychic,
}
public enum BaseStat {
    Strength, Dexterity, Constitution,
    Intelligence, Wisdom, Charisma,
}
public enum Proficency {
    Athletics, Acrobatics, SleightOfHand,
    Stealth, Arcana, History,
    Investigation, Nature, Religion,
    AnimalHandling, Insight, Medicine,
    Perception, Survival, Deception,
    Intimidation, Performance, Persuasion,
}
public enum UnitType { Ft, M, }
public enum CastAnimationType {
    Projectile, Heal, Buff,
}
public enum ActionType {
    Attack, Help, Magic,
    Dodge, Disengage, Dash,
    Hide, Throw,
}
public enum SpellSchool {
    Abjuration, Conjuration, Divination,
    Enchantment, Evocation, Illusion,
    Necromancy, Transmutation,
}
public enum TargetRule {
    Self, Single, AOE,
    Cone, Line,
}
public enum DiceType {
    D4 = 4, D6 = 6, D8 = 8,
    D10 = 10, D12 = 12, D20 = 20,
    D100 = 100,
}
public enum ConditionType {
    None,
    Blinded,
    Charmed,
    Deafened,
    Exhaustion,
    Frightened,
    Grappled,
    Incapacitated,
    Invisible,
    Paralyzed,
    Petrified,
    Poisoned,
    Prone,
    Restrained,
    Stunned,
    Unconscious,
}
