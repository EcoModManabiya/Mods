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
    [Weight(100)]                                          
    public partial class FriedHareHaunchesItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fried Hare Haunches"; } }
        public override string Description                      { get { return "Everything is better deep fried."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 27, Protein = 15, Vitamins = 4};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CulinaryArtsSkill), 3)]    
    public partial class FriedHareHaunchesRecipe : Recipe
    {
        public FriedHareHaunchesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FriedHareHaunchesItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PreparedMeatItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FlourItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<OilItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FriedHareHaunchesRecipe), Item.Get<FriedHareHaunchesItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Fried Hare Haunches", typeof(FriedHareHaunchesRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}