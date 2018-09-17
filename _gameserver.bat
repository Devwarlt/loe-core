FOR /F "tokens=4 delims= " %%P IN ('netstat -a -n -o ^| findstr :7171') DO @ECHO TaskKill.exe /PID %%P
taskkill /f /im GameServer.exe
FOR /F "tokens=4 delims= " %%P IN ('netstat -a -n -o ^| findstr :7171') DO @ECHO TaskKill.exe /PID %%P
taskkill /f /im GameServer.exe
cd server/bin/Debug
start GameServer.exe
exit