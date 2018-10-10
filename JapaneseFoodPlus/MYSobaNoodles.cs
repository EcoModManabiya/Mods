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
    public partial class MYSobaNoodlesItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Soba Noodles"; } }
        public override string Description                      { get { return "Japanese noodles machined using the buckwheat flour which assumes the buckwheat of cereals raw materials with the soba and dish using it."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 63, Fat = 2, Protein = 12, Vitamins = 1};
        public override float Calories                          { get { return 920; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class MYSobaNoodlesRecipe : Recipe
    {
        public MYSobaNoodlesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSobaNoodlesItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 30, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSobaNoodlesRecipe), Item.Get<MYSobaNoodlesItem>().UILink(), 60, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Soba Noodles", typeof(MYSobaNoodlesRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}