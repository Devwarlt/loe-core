FOR /F "tokens=4 delims= " %%P IN ('netstat -a -n -o ^| findstr :7172') DO @ECHO TaskKill.exe /PID %%P
taskkill /f /im GameWebServer.exe
FOR /F "tokens=4 delims= " %%P IN ('netstat -a -n -o ^| findstr :7172') DO @ECHO TaskKill.exe /PID %%P
taskkill /f /im GameWebServer.exe
cd webserver/bin/Debug
start GameWebServer.exe
exit