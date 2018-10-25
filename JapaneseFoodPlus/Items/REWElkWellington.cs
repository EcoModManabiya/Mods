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
    [Weight(500)]                                          
    public partial class ElkWellingtonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Elk Wellington"; } }
        public override string Description                      { get { return "A prime cut of meat surrounded by pastry."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 12, Protein = 20, Vitamins = 8};
        public override float Calories                          { get { return 1400; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(LeavenedBakingSkill), 4)]    
    public partial class ElkWellingtonRecipe : Recipe
    {
        public ElkWellingtonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElkWellingtonItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(LeavenedBakingEfficiencySkill), 25, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(LeavenedBakingEfficiencySkill), 1, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(LeavenedBakingEfficiencySkill), 20, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PrimeCutItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElkWellingtonRecipe), Item.Get<ElkWellingtonItem>().UILink(), 8, typeof(LeavenedBakingSpeedSkill)); 
            this.Initialize("Elk Wellington", typeof(ElkWellingtonRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}