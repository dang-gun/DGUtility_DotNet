# Time Standard - DG Utility .NET 6

지금 시간이 기준 시간을 지났는지 지나지 않았는지에 따라 계산된 날짜를 리턴해주는 라이브러리입니다.

예>
기준 시간 '09:00'이면 '2024-05-21 09:00:00 ~ 2024-05-22 08:59:59' 까지는 '2024-05-21'로 표시됩니다.

반대의 기능도 있습니다.
예>
기준 시간 '09:00'이면 '2024-05-22 09:00:00 ~ 2024-05-23 08:59:59' 까지는 '2024-05-23'로 표시됩니다.

## 사용방법

1. TimeStandard를 생성합니다.

```
TimeStandard tsObj = new TimeStandard(DateTime.Now, true);
```

매개변수

timeLoopTickResetTime : 하루가 시작의 기준 시간<br />
- DateTime를 사용하는 경우 : DateTime.TimeOfDay<br />
- 문자열을 사용하는 경우 : TimeSpan.Parse("00:00:00")<br />

bNextDay : 기준 시간이 지나면 다음날 취급할지 여부
- 기본값 : false
- true : 기준 시간이 지나면 다음날로 취급한다.
- false : 기준 시간 지나기 전까지는 전날로 취급한다.


2. DateToStandard를 호출하여 비교합니다.

지정된 날짜의 기준 날짜를 리턴합니다.

- NextDay == true : LoopTickCountResetTime가 지났다면 내일 날짜를 준다.
- NextDay == false : 지정된 날짜의 시간이 0시이후인데 LoopTickCountResetTime 시간전이라면 전날 날짜를 주게 된다.

```
DateTime dtResult = tsObj.DateToStandard(DateTime.Now);
```

매개변수

dtTarget : 비교할 날짜+시간

리턴 : 년,월,일 만 리턴됨

## 테스트

[테스트용 프로젝트](https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_TimeTest)