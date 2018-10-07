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
    public partial class MYTofuItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Tofu"; } }
        public override string Description                      { get { return "It is the processed food which hardened the juice of the soybean by a coagulating agent."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 3, Protein = 5, Vitamins = 1};
        public override float Calories                          { get { return 150; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class MYTofuRecipe : Recipe
    {
        public MYTofuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTofuItem>(5),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeansItem>(30), 
                new CraftingElement<ClothItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTofuRecipe), Item.Get<MYTofuItem>().UILink(), 120, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Tofu", typeof(MYTofuRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}