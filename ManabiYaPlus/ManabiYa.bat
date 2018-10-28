@echo off

set /p ui=Install ManabiYa Mod:[Y] / UnInstall:[N] and Enter:

if %ui%==Y set result=true
if %ui%==y set result=true
if %ui%==N set result=false
if %ui%==n set result=false

if %result%==true (
	echo Override the file.
	ren ..\Objects\ComputerLabObject.cs ComputerLabObject.csbak	
	ren ..\Objects\LaserObject.cs LaserObject.csbak	
	ren ..\AutoGen\Item\Board.cs Board.csbak	
	ren ..\AutoGen\Vehicle\Truck.cs Truck.csbak	
	ren ..\Items\Tailings.cs Tailings.csbak	
	ren ..\Objects\WorldObject\Laboratory.cs Laboratory.csbak	
) else if %result%==false (
	echo Restore to original files. And You must delete ManabiYa Mod.
	ren ..\Objects\*.csbak *.cs
	ren ..\AutoGen\Item\*.csbak *.cs	
	ren ..\AutoGen\Vehicle\*.csbak *.cs	
	ren ..\Items\*.csbak *.cs	
	ren ..\Objects\WorldObject\*.csbak *.cs	
)
@pause