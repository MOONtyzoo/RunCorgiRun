using System.Collections;
using System.Collections.Generic;
using System.Security;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public static class GameParameters
{
    public static int GameplayDuration = 60;

    public static float CorgiMoveSpeed = 7.5f;
    public static float CorgiDrunkenMoveSpeed = 4.5f;
    public static float CorgiPlasteredMoveSpeed = 8.3f;
    public static float CorgiDrunkSeconds = 3.0f;

    public static float PoopLifetime = 5.0f;

    public static float BeerLifetime = 7.5f;
    public static NumberRange BeerSpawnerCooldownRange = new NumberRange(0.7f, 1.8f);
    
    public static float BoneLifetime = 10.0f;
    public static NumberRange BoneSpawnerCooldownRange = new NumberRange(0.7f, 1.5f);

    public static float PillLifetime = 30.0f;
    public static NumberRange PillSpawnerCooldownRange = new NumberRange(6.5f, 10.5f);

    public static float MoonshineFallSpeed = 5.8f;
    public static float MoonshineLifetime = 5.0f;
    public static NumberRange MoonshineSpawnerCooldownRange = new NumberRange(0.5f, 1.5f);
    public static float MoonshineCooldownMultiplierAtGameEnd = 0.33f;
}
