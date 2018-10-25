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
    [Weight(500)]                                          
    public partial class BearSUPREMEItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Bear S U P R E M E"; } }
        public override string Description                      { get { return "Just because the name has 'bear' in it doesn't mean it actually contains bear."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 22, Protein = 20, Vitamins = 10};
        public override float Calories                          { get { return 1200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class BearSUPREMERecipe : Recipe
    {
        public BearSUPREMERecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BearSUPREMEItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<VegetableMedleyItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MeatStockItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<InfusedOilItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BearSUPREMERecipe), Item.Get<BearSUPREMEItem>().UILink(), 20, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Bear S U P R E M E", typeof(BearSUPREMERecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}