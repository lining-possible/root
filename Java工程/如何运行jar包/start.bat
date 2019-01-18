@echo off  
SET JAVA_HOME=%cd%\jre1.8.0_101
SET Classpath=%JAVA_HOME%\lib\tools.jar;%JAVA_HOME%\lib\dt.jar;
SET Path=%JAVA_HOME%\bin
echo %JAVA_HOME%
java -version
title 监控气体和火灾每日报警数量
java -jar F:\software\MyEclipse_10.7_XiaZaiBa\MyEclipse 破解文件+破解说明\cracker.jar >>log.txt
pause