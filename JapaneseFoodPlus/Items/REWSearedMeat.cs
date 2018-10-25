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
    public partial class SearedMeatItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Seared Meat"; } }
        public override string FriendlyNamePlural               { get { return "Seared Meat"; } } 
        public override string Description                      { get { return "A cut of perfectly seared steak."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 17, Protein = 19, Vitamins = 7};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CulinaryArtsSkill), 2)]    
    public partial class SearedMeatRecipe : Recipe
    {
        public SearedMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SearedMeatItem>(),
               
               new CraftingElement<TallowItem>(1), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<InfusedOilItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SearedMeatRecipe), Item.Get<SearedMeatItem>().UILink(), 8, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Seared Meat", typeof(SearedMeatRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}