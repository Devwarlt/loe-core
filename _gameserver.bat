FOR /F "tokens=4 delims= " %%P IN ('netstat -a -n -o ^| findstr :7171') DO @ECHO TaskKill.exe /PID %%P
taskkill /f /im BRMEServer.exe
FOR /F "tokens=4 delims= " %%P IN ('netstat -a -n -o ^| findstr :7171') DO @ECHO TaskKill.exe /PID %%P
taskkill /f /im BRMEServer.exe
cd server/bin/Debug
start BRMEServer.exe
exit