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
    public partial class MYTempuraItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Tempura"; } }
        public override string Description                      { get { return "It is Japanese food that the tempura fries the ingredients such as fishery products or vegetables in a parcel, oil with clothes mainly composed of the wheat flour and cooks."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 21, Fat = 12, Protein = 11, Vitamins = 2};
        public override float Calories                          { get { return 690; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 3)]    
    public partial class MYTempuraRecipe : Recipe
    {
        public MYTempuraRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTempuraItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FireweedShootsItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<CriminiMushroomsItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<RawFishItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTempuraRecipe), Item.Get<MYTempuraItem>().UILink(), 30, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Tempura", typeof(MYTempuraRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}