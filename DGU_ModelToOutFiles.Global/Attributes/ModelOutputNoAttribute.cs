﻿using System;

namespace DGU_ModelToOutFiles.Global.Attributes;

/// <summary>
/// 파일 출력시 이 개체는 제외한다.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class 
    | AttributeTargets.Enum
    | AttributeTargets.Property)]
public class ModelOutputNoAttribute : Attribute
{
    /// <summary>
    /// 다른 프로젝트로 변환하는 경우 이 개체를 제외할지 여부
    /// </summary>
    /// <remarks>
    /// true이면 출력하지 않는다.
    /// </remarks>
    public bool OutputNoIs;

    public ModelOutputNoAttribute()
    {
        this.OutputNoIs = true;
    }
}

/// <summary>
/// EnumTypeAttribute가 있는지 확인하고 있으면 개체를 리턴해주는 클래스
/// </summary>
public class OutputNoAttributeCheck
{
    public ModelOutputNoAttribute? Check(Type type)
    {
        ModelOutputNoAttribute? etReturn =
            type.GetCustomAttributes(typeof(ModelOutputNoAttribute), false)
                    .Cast<ModelOutputNoAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }
}