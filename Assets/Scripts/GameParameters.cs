using System.Collections;
using System.Collections.Generic;
using System.Security;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public static class GameParameters
{
    public static float CorgiMoveSpeed = 5.0f;
    public static float CorgiDrunkSeconds = 5.0f;

    public static float PoopLifetime = 5.0f;

    public static float BeerLifetime = 5.0f;
    public static NumberRange BeerSpawnerCooldownRange = new NumberRange(1.25f, 2.75f);
    
    public static float BoneLifetime = 10.0f;
    public static NumberRange BoneSpawnerCooldownRange = new NumberRange(2.5f, 7.5f);

    public static float PillLifetime = 7.0f;
    public static NumberRange PillSpawnerCooldownRange = new NumberRange(2.5f, 7.5f);

    public static float MoonshineFallSpeed = 5.0f;
    public static float MoonshineLifetime = 5.0f;
    public static NumberRange MoonshineSpawnerCooldownRange = new NumberRange(0.5f, 1.0f);
}
