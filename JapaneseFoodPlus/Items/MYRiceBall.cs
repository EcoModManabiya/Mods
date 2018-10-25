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
    public partial class MYRiceBallItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Rice Ball"; } }
        public override string Description                      { get { return "A japanese rice ball. They usually make it in a triangle."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 38, Fat = 0, Protein = 3, Vitamins = 2};
        public override float Calories                          { get { return 173; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHighestNigiriSkill), 1)]    
    public partial class MYRiceBallRecipe : Recipe
    {
        public MYRiceBallRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYRiceBallItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(10),
                new CraftingElement<MYNoriItem>(1), 
                new CraftingElement<MYSaltedPlumItem>(1), 
                new CraftingElement<MYSaltItem>(typeof(MYHighestNigiriEfficiencySkill), 5, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRiceBallRecipe), Item.Get<MYRiceBallItem>().UILink(), 2, typeof(MYHighestNigiriSpeedSkill)); 
            this.Initialize("Rice Ball", typeof(MYRiceBallRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}