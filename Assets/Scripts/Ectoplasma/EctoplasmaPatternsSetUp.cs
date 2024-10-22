﻿using UnityEngine;

public class EctoplasmaPatternsSetUp : MonoBehaviour
{    
    [Space(15)]
    public float walking_speed = 0.7f;
    public float pause_between_patterns = 5f;

    [Space(15)]
    public bool fireball_shoot_pattern = true;
    public float shooting_speed = 3;
    public int fireballs_count = 5;

    [Space(15)]
    public bool MeteoriteRainPattern = true;
    public int meteorites_count = 10;
    public float rain_duration = 2f;

    [Space(15)]
    public bool WideFrontalAttackPattern = true;
    public float fire_duration = 5f;

}
