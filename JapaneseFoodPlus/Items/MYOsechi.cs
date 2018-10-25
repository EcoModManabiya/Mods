namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(150)]                                          
    public partial class MYOsechiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Osechi"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Osechi"; } } 
        public override string Description                      { get { return "Osechi are Japanese New Year's dishes that are specially prepared to be eaten during the first three days of January."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 166, Fat = 20, Protein = 43, Vitamins = 12};
        public override float Calories                          { get { return 988; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 4)]    
    public partial class MYOsechiRecipe : Recipe
    {
        public MYOsechiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYOsechiItem>(3),
                new CraftingElement<MYWoodenPlateItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 15, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 3, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYBoiledFishItem>(3), 
                new CraftingElement<BakedRoastItem>(3), 
                new CraftingElement<MYDashimakiTamagoItem>(3), 
                new CraftingElement<MYDengakuItem>(3), 
                new CraftingElement<MYPickleItem>(3), 
                new CraftingElement<BeetItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BeansItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<ClamItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<UrchinItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(3), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYOsechiRecipe), Item.Get<MYOsechiItem>().UILink(), 30, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Osechi", typeof(MYOsechiRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}