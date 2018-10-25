@echo off

set /p ui=Install ManabiYa Mod:[Y] / UnInstall:[N] and Enter:

if %ui%==Y set result=true
if %ui%==y set result=true
if %ui%==N set result=false
if %ui%==n set result=false

if %result%==true (
	echo Override the file.
	ren ..\Tools\AxeItem.cs AxeItem.csbak	
	ren ..\AutoGen\Food\BoiledShoots.cs BoiledShoots.csbak
	ren ..\AutoGen\Food\CamasMash.cs CamasMash.csbak
	ren ..\AutoGen\Food\RiceSludge.cs RiceSludge.csbak
	ren ..\AutoGen\Food\Bannock.cs Bannock.csbak
	ren ..\AutoGen\Food\CampfireStew.cs CampfireStew.csbak
	ren ..\AutoGen\Food\FriedTomatoes.cs FriedTomatoes.csbak
	ren ..\AutoGen\Food\WheatPorridge.cs WheatPorridge.csbak
	ren ..\AutoGen\Food\WildStew.cs WildStew.csbak
	ren ..\AutoGen\Recipe\ExoticFruitSalad.cs ExoticFruitSalad.csbak
	ren ..\AutoGen\Recipe\ExoticSalad.cs ExoticSalad.csbak
	ren ..\AutoGen\Recipe\ExoticVegetableMedley.cs ExoticVegetableMedley.csbak
	ren ..\AutoGen\Recipe\ForestSalad.cs ForestSalad.csbak
	ren ..\AutoGen\Recipe\GrasslandSalad.cs GrasslandSalad.csbak
	ren ..\AutoGen\Recipe\MixedFruitSalad.cs MixedFruitSalad.csbak
	ren ..\AutoGen\Recipe\MixedSalad.cs MixedSalad.csbak
	ren ..\AutoGen\Recipe\MixedVegetableMedley.cs MixedVegetableMedley.csbak
	ren ..\AutoGen\Food\CrispyBacon.cs CrispyBacon.csbak
	ren ..\AutoGen\Food\MeatStock.cs MeatStock.csbak
	ren ..\AutoGen\Recipe\StuffedTurkey.cs StuffedTurkey.csbak
	ren ..\AutoGen\Recipe\VegetableSoup.cs VegetableSoup.csbak
	ren ..\AutoGen\Recipe\VegetableStock.cs VegetableStock.csbak
	ren ..\AutoGen\Food\SimmeredMeat.cs SimmeredMeat.csbak
	ren ..\AutoGen\Food\ElkWellington.cs ElkWellington.csbak
	ren ..\AutoGen\Food\CamasBulbBake.cs CamasBulbBake.csbak
	ren ..\AutoGen\Food\BakedMeat.cs BakedMeat.csbak
	ren ..\AutoGen\Food\BakedRoast.cs BakedRoast.csbak
	ren ..\AutoGen\Food\CrimsonSalad.cs CrimsonSalad.csbak
	ren ..\AutoGen\Food\HuckleberryExtract.cs HuckleberryExtract.csbak
	ren ..\AutoGen\Food\SimpleSyrup.cs SimpleSyrup.csbak
	ren ..\AutoGen\Food\Tortilla.cs Tortilla.csbak
	ren ..\AutoGen\Food\BearSUPREME.cs BearSUPREME.csbak
	ren ..\AutoGen\Food\BoiledSausage.cs BoiledSausage.csbak
	ren ..\AutoGen\Food\CornFritters.cs CornFritters.csbak
	ren ..\AutoGen\Food\ElkTaco.cs ElkTaco.csbak
	ren ..\AutoGen\Food\FriedHareHaunches.cs FriedHareHaunches.csbak
	ren ..\AutoGen\Food\RefineTallow.cs RefineTallow.csbak
	ren ..\AutoGen\Food\SearedMeat.cs SearedMeat.csbak
	ren ..\AutoGen\Food\CampfireRoast.cs CampfireRoast.csbak
	ren ..\AutoGen\Food\CharredSausage.cs CharredSausage.csbak
	ren ..\AutoGen\Recipe\RenderFat.cs RenderFat.csbak
) else if %result%==false (
	echo Restore to original files. And You must delete ManabiYa Mod.
	ren ..\Tools\*.csbak *.cs
	ren ..\AutoGen\Food\*.csbak *.cs	
	ren ..\AutoGen\Recipe\*.csbak *.cs
)
@pause
