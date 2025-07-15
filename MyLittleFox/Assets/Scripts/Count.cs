using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Unit_Type
{
    None = 0,
    /// <summary>
    /// 玩家
    /// </summary>
    Player,

    /// <summary>
    /// 敌人
    /// </summary>
    Enemy,
}

public enum Enemy_type
{
    None = 0,
    /// <summary>
    /// 青蛙
    /// </summary>
    Frog,

    /// <summary>
    /// 鹰
    /// </summary>
    Eagle,
    /// <summary>
    /// 负鼠
    /// </summary>
    Opossum,
}

//得分类型
public enum Item_Type
{
    None,
    Cherry,
    Gem,
}