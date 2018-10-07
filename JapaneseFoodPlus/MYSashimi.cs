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
    [Weight(50)]                                          
    public partial class MYSashimiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Sashimi"; } }
        public override string Description                      { get { return "A dish to slice raw fish meat, and to attach soy sauce, and to eat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 1, Protein = 10, Vitamins = 1};
        public override float Calories                          { get { return 150; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class MYSashimiRecipe : Recipe
    {
        public MYSashimiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSashimiItem>(10),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(1), 
                new CraftingElement<MYSoySauceItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSashimiRecipe), Item.Get<MYSashimiItem>().UILink(), 10, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Sashimi", typeof(MYSashimiRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}