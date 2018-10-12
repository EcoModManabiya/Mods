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
    public partial class MYNigiriSushiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Nigiri Sushi"; } }
        public override string Description                      { get { return "It is the sushi which the finger sushi puts a sushi seed on the nubbin of the vinegar meal and made."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 22, Fat = 3, Protein = 10, Vitamins = 1};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 2)]    
    public partial class MYNigiriSushiRecipe : Recipe
    {
        public MYNigiriSushiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNigiriSushiItem>(1),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYSashimiItem>(1), 
                new CraftingElement<RiceItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNigiriSushiRecipe), Item.Get<MYNigiriSushiItem>().UILink(), 10, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Nigiri Sushi", typeof(MYNigiriSushiRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}