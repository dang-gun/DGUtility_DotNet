﻿namespace DGU_ModelToOutFiles.TestModels.TestCont;

/// <summary>
/// 일반 출력 테스트
/// </summary>
public class TestCallModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int { get; set; }

    /// <summary>
    /// 문자열
    /// </summary>
    public string String { get; set; } = string.Empty;

    /// <summary>
    /// 날짜
    /// </summary>

    public DateTime? DateTime { get; set; }
}
