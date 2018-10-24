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
    public partial class CamasMashItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Camas Mash"; } }
        public override string FriendlyNamePlural               { get { return "Camas Mash"; } } 
        public override string Description                      { get { return "A mushy camas paste with some fat added for flavor and texture."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 1, Fat = 9, Protein = 2, Vitamins = 1};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    public partial class CamasMashRecipe : Recipe
    {
        public CamasMashRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasMashItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(2),
                new CraftingElement<TallowItem>(1),    
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = new ConstantValue(2);     
            this.Initialize("Camas Mash", typeof(CamasMashRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}