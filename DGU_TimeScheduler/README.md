# Time Scheduler - DGUtility


일정 주기마다 이벤트를 발생시키는 라이브러리입니다.
- 하루, 기준 날짜 변경 이벤트
- 지정한 간격 마다 이벤트

기준 시간을 지정하면 지금 시간이 지정한 시간을 지났는지 지나지 않았는지에 따라 가지고 있는 날짜를 변경합니다.


예>
기준 시간 '09:00'이면 '2024-05-21 09:00:00 ~ 2024-05-22 08:59:59' 까지는 '2024-05-21'로 표시됩니다.
![이미지](https://raw.githubusercontent.com/dang-gun/DGUtility_DotNet/main/DGU_TimeTest/ProjectFiles/DGU_TimeStandard_001.png)

반대의 기능도 있습니다.
예>
기준 시간 '09:00'이면 '2024-05-22 09:00:00 ~ 2024-05-23 08:59:59' 까지는 '2024-05-23'로 표시됩니다.
![이미지](https://raw.githubusercontent.com/dang-gun/DGUtility_DotNet/main/DGU_TimeTest/ProjectFiles/DGU_TimeStandard_002.png)


## 사용방법
1. TimeScheduler를 생성합니다.


```
TimeScheduler tsObj = new TimeScheduler(DateTime.Now, true);
```

매개변수

timeLoopTickResetTime : 하루가 시작의 기준 시간<br />
- DateTime를 사용하는 경우 : DateTime.TimeOfDay<br />
- 문자열을 사용하는 경우 : TimeSpan.Parse("00:00:00")<br />

bNextDay : 기준 시간이 지나면 다음날 취급할지 여부
- 기본값 : false
- true : 기준 시간이 지나면 다음날로 취급한다.
- false : 기준 시간 지나기 전까지는 전날로 취급한다.


2. 간격 이벤트 개체 생성

다음과 같은 방법을 통해 간격 이벤트를 추가할 수 있습니다.
- TimeScheduler.StopWatchList에 직접 접근하여 StopWatchDataModel를 추가
- TimeScheduler.StopWatch_Add를 이용하여 추가


3. 날짜 변경 이벤트 연결

생성한 TimeScheduler 개체에 날짜 변경 이벤트를 연결합니다.

날짜 변경 이벤트는 2가지가 있습니다.
- On1Day : 컴퓨터 기준 하루가 변경 되었을때
- On1DayStandard : 기준 시간에 도달할여 다음날로 바뀔때

