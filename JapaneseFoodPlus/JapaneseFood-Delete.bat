@echo off

set /p ui=Install ManabiYa Mod:[Y] / UnInstall:[N] and Enter:

if %ui%==Y set result=true
if %ui%==y set result=true
if %ui%==N set result=false
if %ui%==n set result=false

if %result%==true (
	echo Override the file.
	ren ..\AutoGen\Recipe\ButcherTurkey.cs ButcherTurkey.csdel
) else if %result%==false (
	echo Restore to original files. And You must delete ManabiYa Mod.
	ren ..\AutoGen\Recipe\*.csdel *.cs
)
@pause
