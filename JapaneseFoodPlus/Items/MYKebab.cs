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
    public partial class MYKebabItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Kebab"; } }
        public override string Description                      { get { return "A Middle Eastern dish of the origin in Turkey."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 22, Fat = 8, Protein = 14, Vitamins = 31};
        public override float Calories                          { get { return 218; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(MYCharcoalGrillSkill), 3)]    
    public partial class MYKebabRecipe : Recipe
    {
        public MYKebabRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYKebabItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYCharcoalGrillEfficiencySkill), 30, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MYWoodenPlateItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYCharcoalGrillEfficiencySkill), 1, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(typeof(MYCharcoalGrillEfficiencySkill), 5, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<VegetableMedleyItem>(typeof(MYCharcoalGrillEfficiencySkill), 30, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlatbreadItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<PaperItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYKebabRecipe), Item.Get<MYKebabItem>().UILink(), 10, typeof(MYCharcoalGrillSpeedSkill)); 
            this.Initialize("Kebab", typeof(MYKebabRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}