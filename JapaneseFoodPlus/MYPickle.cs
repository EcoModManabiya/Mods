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
    [Weight(10)]                                          
    public partial class MYPickleItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Pickle"; } }
        public override string Description                      { get { return "Various ingredients such as salt, vinegar, the sake lees the food which pickled it, and pickled it with materials, and let raised preservation characteristics, and mature, and made a flavor better."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 0, Protein = 1, Vitamins = 4};
        public override float Calories                          { get { return 8; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYBestSmellSkill), 1)]    
    public partial class MYPickleRecipe : Recipe
    {
        public MYPickleRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYPickleItem>(20),
                new CraftingElement<GarbageItem>(typeof(MYBestSmellEfficiencySkill), 2, MYBestSmellEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetItem>(20), 
                new CraftingElement<MYMisoItem>(typeof(MYBestSmellEfficiencySkill), 20, MYBestSmellEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlatterItem>(20), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYPickleRecipe), Item.Get<MYPickleItem>().UILink(), 120, typeof(MYBestSmellSpeedSkill)); 
            this.Initialize("Pickle", typeof(MYPickleRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}