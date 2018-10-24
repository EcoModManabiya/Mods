@echo off

set /p ui=Install ManabiYa Mod:[Y] / UnInstall:[N] and Enter:

if %ui%==Y set result=true
if %ui%==y set result=true
if %ui%==N set result=false
if %ui%==n set result=false

if %result%==true (
	echo Override the file.
	ren ..\Tools\AxeItem.cs AxeItem.csbak	
	ren ..\AutoGen\Food\BoiledShootsRecipe.cs BoiledShootsRecipe.csbak
	ren ..\AutoGen\Food\CamasMash.cs CamasMash.csbak
	ren ..\AutoGen\Food\RiceSludge.cs RiceSludge.csbak
	ren ..\AutoGen\Food\WiltedFiddleheads.cs WiltedFiddleheads.csbak
	ren ..\AutoGen\Food\Bannock.cs Bannock.csbak
	ren ..\AutoGen\Food\CampfireStew.cs CampfireStew.csbak
	ren ..\AutoGen\Food\FriedTomatoes.cs FriedTomatoes.csbak
	ren ..\AutoGen\Food\WheatPorridge.cs WheatPorridge.csbak
	ren ..\AutoGen\Food\WildStew.cs WildStew.csbak
) else if %result%==false (
	echo Restore to original files. And You must delete ManabiYa Mod.
	ren ..\Tools\*.csbak *.cs
	ren ..\AutoGen\Food\*.csbak *.cs	
)
@pause