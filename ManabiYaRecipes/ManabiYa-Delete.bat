@echo off

set /p ui=Install ManabiYa Mod:[Y] / UnInstall:[N] and Enter:

if %ui%==Y set result=true
if %ui%==y set result=true
if %ui%==N set result=false
if %ui%==n set result=false

if %result%==true (
	echo Override the file.
	ren ..\AutoGen\Item\Lumber.cs Lumber.csdel
	ren ..\AutoGen\WorldObject\BisonMount.cs BisonMount.csdel
	ren ..\AutoGen\WorldObject\ElkMount.cs ElkMount.csdel
	ren ..\AutoGen\WorldObject\SaltBasket.cs SaltBasket.csdel
	ren ..\AutoGen\WorldObject\StuffedElk.cs StuffedElk.csdel
	ren ..\AutoGen\WorldObject\Couch.cs Couch.csdel
) else if %result%==false (
	echo Restore to original files. And You must delete ManabiYa Mod.
	ren ..\AutoGen\Item\*.csdel *.cs
	ren ..\AutoGen\WorldObject\*.csdel *.cs
)
@pause
