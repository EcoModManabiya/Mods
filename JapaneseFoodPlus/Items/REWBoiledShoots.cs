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
    public partial class BoiledShootsItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Boiled Shoots"; } }
        public override string FriendlyNamePlural               { get { return "Boiled Shoots"; } } 
        public override string Description                      { get { return "Boiled in water to remove the inherent bitterness, this shoot is much tastier."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 1, Protein = 0, Vitamins = 9};
        public override float Calories                          { get { return 510; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    public partial class BoiledShootsRecipe : Recipe
    {
        public BoiledShootsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoiledShootsItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FireweedShootsItem>(2),    
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = new ConstantValue(2);     
            this.Initialize("Boiled Shoots", typeof(BoiledShootsRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}