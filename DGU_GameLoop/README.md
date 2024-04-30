# Game Loop - DGUtility

'Stopwatch'기반 게임루프 입니다.

[고해상도 타임스탬프 획득 - MS Learn Link](https://learn.microsoft.com/ko-kr/windows/win32/sysinfo/acquiring-high-resolution-time-stamps)

## Stopwatch기반 게임루프를 사용해야 하는 이유

'Environment.TickCount'나 'TimeSpan'를 사용하는 경우 운영체제 별로 정확도 차이가 생깁니다.
[[.NET] 게임 루프(Game Loop)를 구현할 때는 'Environment.TickCount'를 사용하면 안 된다.](https://blog.danggun.net/10016)

'Stopwatch'는 'Stopwatch'를 사용할 수 없는 상황에서만 'Environment.TickCount'을 사용합니다.



