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
    public partial class MYMisoSoupItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Miso Soup"; } }
        public override string Description                      { get { return "The miso soup is one of the soup in the Japanese food and is the soup of dish which assumed the food such as vegetables and tofu, 麸 or fishery products a fruit to the juice which seasoned soup stock with miso."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 1, Protein = 2, Vitamins = 1};
        public override float Calories                          { get { return 90; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYMisoSoupRecipe : Recipe
    {
        public MYMisoSoupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYMisoSoupItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYMisoItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYTofuItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<ClamItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<KelpItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYMisoSoupRecipe), Item.Get<MYMisoSoupItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Miso Soup", typeof(MYMisoSoupRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}