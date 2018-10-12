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
    public partial class MYGyudonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Gyudon"; } }
        public override string Description                      { get { return "It is salty-sweet and stews beef and the onion which I sliced with soy sauce, and a beef bowl is the dish which I picked up on the meal which I served in a bowl."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 100, Fat = 16, Protein = 20, Vitamins = 2};
        public override float Calories                          { get { return 2000; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 4)]    
    public partial class MYGyudonRecipe : Recipe
    {
        public MYGyudonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGyudonItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20), 
                new CraftingElement<ScrapMeatItem>(typeof(HomeCookingEfficiencySkill), 30, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGyudonRecipe), Item.Get<MYGyudonItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Gyudon", typeof(MYGyudonRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}