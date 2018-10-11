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
    [Weight(50)]                                          
    public partial class MYNoriItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Nori"; } }
        public override string Description                      { get { return "Straight laver or the board laver which processed an alga are eaten and become the important materials with a side dish or sushi of the boiled rice."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 3, Protein = 10, Vitamins = 1};
        public override float Calories                          { get { return 50; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(FishingSkill), 4)]    
    public partial class MYNoriRecipe : Recipe
    {
        public MYNoriRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNoriItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<KelpItem>(typeof(FishingSkill), 20, FishingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNoriRecipe), Item.Get<MYNoriItem>().UILink(), 120, typeof(FishingSkill)); 
            this.Initialize("Nori", typeof(MYNoriRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}