@echo off  
SET JAVA_HOME=%cd%\jre1.8.0_101
SET Classpath=%JAVA_HOME%\lib\tools.jar;%JAVA_HOME%\lib\dt.jar;
SET Path=%JAVA_HOME%\bin
echo %JAVA_HOME%
java -version
title �������ͻ���ÿ�ձ�������
java -jar F:\software\MyEclipse_10.7_XiaZaiBa\MyEclipse �ƽ��ļ�+�ƽ�˵��\cracker.jar >>log.txt
pause