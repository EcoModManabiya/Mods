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
    public partial class MYBoiledTofuItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Boiled Tofu"; } }
        public override string Description                      { get { return "It is one of the Japanese foods and is food served in a pot using the tofu."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 5, Protein = 10, Vitamins = 2};
        public override float Calories                          { get { return 350; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYBoiledTofuRecipe : Recipe
    {
        public MYBoiledTofuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBoiledTofuItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<KelpItem>(typeof(HomeCookingEfficiencySkill), 2, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<CriminiMushroomsItem>(typeof(HomeCookingEfficiencySkill), 2, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYTofuItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(HomeCookingEfficiencySkill), 2, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBoiledTofuRecipe), Item.Get<MYBoiledTofuItem>().UILink(), 60, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Boiled Tofu", typeof(MYBoiledTofuRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}