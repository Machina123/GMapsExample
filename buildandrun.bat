@echo off
title Budowanie aplikacji...
call ant debug

timeout /t 1 /nobreak

title Instalowanie aplikacji...
call adb install -r bin\gmaps001-debug.apk


timeout /t 1 /nobreak

title Uruchamianie aplikacji...
call adb shell am start -n net.machina.projekty.gmaps001/.gmaps001


timeout /t 1 /nobreak

echo.
echo.
echo ZROBIONE
echo.
echo.
timeout /t 10
exit