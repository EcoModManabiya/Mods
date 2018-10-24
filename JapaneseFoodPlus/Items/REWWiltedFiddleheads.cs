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
    [Weight(200)]                                          
    public partial class WiltedFiddleheadsItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Wilted Fiddleheads"; } }
        public override string FriendlyNamePlural               { get { return "Wilted Fiddleheads"; } } 
        public override string Description                      { get { return "While a bunch of wilted fiddleheads may seem a bit sad, at least they're nutritious."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 0, Protein = 1, Vitamins = 8};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    public partial class WiltedFiddleheadsRecipe : Recipe
    {
        public WiltedFiddleheadsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WiltedFiddleheadsItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiddleheadsItem>(6),    
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = new ConstantValue(2);     
            this.Initialize("Wilted Fiddleheads", typeof(WiltedFiddleheadsRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}