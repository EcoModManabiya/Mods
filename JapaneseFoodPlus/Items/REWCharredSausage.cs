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
    [Weight(300)]                                          
    public partial class CharredSausageItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Sausage"; } }
        public override string Description                      { get { return "A blacked sausage filled with meat, fat, and deliciousness."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 15, Protein = 11, Vitamins = 0};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CampfireCreationsSkill), 2)]    
    public partial class CharredSausageRecipe : Recipe
    {
        public CharredSausageRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredSausageItem>(),
               
               new CraftingElement<TallowItem>(1), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawSausageItem>(typeof(CampfireCreationsEfficiencySkill), 4, CampfireCreationsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredSausageRecipe), Item.Get<CharredSausageItem>().UILink(), 7, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Charred Sausage", typeof(CharredSausageRecipe));
            CraftingComponent.AddRecipe(typeof(MYMortarOvenObject), this);
        }
    }
}