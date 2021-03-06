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
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Sashimi"; } } 
        public override string Description                      { get { return "A dish of sliced raw fish that it is eat with japanese soy souce."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 6, Protein = 10, Vitamins = 3};
        public override float Calories                          { get { return 100; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYCuttingBoardObject))]          
    [RequiresSkill(typeof(MYHighestNigiriSkill), 1)]    
    public partial class MYSashimiRecipe : Recipe
    {
        public MYSashimiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSashimiItem>(3),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(1), 
                new CraftingElement<MYSoySauceItem>(typeof(MYHighestNigiriEfficiencySkill), 5, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(3), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSashimiRecipe), Item.Get<MYSashimiItem>().UILink(), 3, typeof(MYHighestNigiriSpeedSkill)); 
            this.Initialize("Sashimi", typeof(MYSashimiRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}