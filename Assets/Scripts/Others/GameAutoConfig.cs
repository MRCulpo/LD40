using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAutoConfig : Singleton<GameAutoConfig>
{
    [Header("Tempo para poder soltar o cocô")]
    public Vector2 m_RangeTimeShit;

    [Header("Tempo para dormir")]
    public Vector2 m_RangeTimeSleep;

    [Header("Tempo para mnanter parado")]
    public Vector2 m_RangeTimeIdle;

    [Header("Chance de dropar biscoito em %")]
    public float m_PercentageDropBiscuit;

    [Header("Tempo que chama para aplicar  a toxina no jogador")]
    public float m_TimeApplyToxin;

    [Header("Divisor de dificuldade - Quando maior mais facil")]
    public int m_DividerDificultToxin = 1;


}
