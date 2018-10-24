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
    [Weight(1000)]                                          
    public partial class StuffedTurkeyItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Stuffed Turkey"; } }
        public override string Description                      { get { return "To give thanks for fact that this food items gives two nutrients more than other food at the same tier."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 12, Protein = 16, Vitamins = 7};
        public override float Calories                          { get { return 1500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(HomeCookingSkill), 4)]    
    public partial class StuffedTurkeyRecipe : Recipe
    {
        public StuffedTurkeyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StuffedTurkeyItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(HomeCookingEfficiencySkill), 4, HomeCookingEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BreadItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<VegetableMedleyItem>(typeof(HomeCookingEfficiencySkill), 4, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StuffedTurkeyRecipe), Item.Get<StuffedTurkeyItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Stuffed Turkey", typeof(StuffedTurkeyRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}