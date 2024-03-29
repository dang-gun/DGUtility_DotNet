﻿using DGU_ModelToOutFiles.TestModels.TestCont;
using DGU_ModelToOutFiles.TestModels.TestCont.Children;
using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels2.TestModels;

/// <summary>
/// 테스트용 호출 모델
/// </summary>
public class TestFindReferenceModel
{
    /// <summary>
    /// 다른 어셈블리에 있는 참조
    /// </summary>
    public TestGeneralTypeModel[]? TestArray { get; set; }

    /// <summary>
    /// ICollection처리
    /// </summary>
    public ICollection<TestObjectModel>? TestICollection { get; set; }

    /// <summary>
    /// 리스트 테스트
    /// </summary>
    public List<TestObjectModel>? TestList { get; set; }

    /// <summary>
    /// 열거형 테스트
    /// </summary>
    public EnumType? TestEnumType { get; set; }

    /// <summary>
    /// 자식 모델 참조 테스트
    /// </summary>
    public ChildrenModel TestChildrenReference { get; set; } = new ChildrenModel();

    /// <summary>
    /// 변수형 강제지정 테스트
    /// </summary>
    [VarTypeEnforce("ReadableStream<Uint8Array> | ArrayBuffer | string")]
    public byte[] TestVarTypeEnforce { get; set; } = new byte[0];
}
