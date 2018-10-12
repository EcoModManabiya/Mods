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

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 0, Protein = 1, Vitamins = 2};
        public override float Calories                          { get { return 50; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYPickleRecipe : Recipe
    {
        public MYPickleRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYPickleItem>(20),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetItem>(20), 
                new CraftingElement<YeastItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYPickleRecipe), Item.Get<MYPickleItem>().UILink(), 240, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Pickle", typeof(MYPickleRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}